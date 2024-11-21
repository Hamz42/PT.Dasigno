using Serilog.Events;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using PT.Dasigno.BLL.Extensions.ServiceCollection;
using PT.Dasigno.BLL.Extensions.ApplicationBuilder;
using PT.Dasigno.DAL.Context.ContextDasigno;
using Microsoft.EntityFrameworkCore;
using PT.Dasigno.BLL.Mappings;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(AutoMapperProfile).Assembly);

// Configurar servicios
ControllersConfig.AddControllersExtend(builder.Services);  // Configuración de Controllers
builder.Services.AddDependency(builder.Configuration);  // Inyecciones de dependencias
DbContextConfig.AddDbContexts(builder.Services, builder.Configuration); // Configuración del DbContext

// Configurar Serilog
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

// Crear la aplicación
var app = builder.Build();

// Crear la base de datos y aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<dbContextDasigno>();
    context.Database.EnsureCreated(); // Crear la base de datos si no existe
    //context.Database.Migrate(); // Aplicar migraciones

    // Configurar Serilog para crear la tabla de logs después de aplicar migraciones
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.MSSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            sinkOptions: new MSSqlServerSinkOptions()
            {
                TableName = "DasignoApiLog",
                SchemaName = "dbo",
                AutoCreateSqlTable = true
            })
        .CreateLogger();
}

// Configurar middleware y pipeline
app.InitconfigurationAPI(app.Environment); // Configuración desacoplada del pipeline

app.Run();
