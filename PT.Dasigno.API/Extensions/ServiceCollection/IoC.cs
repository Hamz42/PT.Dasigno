using PT.Dasigno.BLL.Interfaces.Base;
using PT.Dasigno.BLL.Interfaces.Repository;
using PT.Dasigno.BLL.Interfaces.Repository.Base;
using PT.Dasigno.BLL.Interfaces.Services;
using PT.Dasigno.BLL.Persistence.Base;
using PT.Dasigno.BLL.Persistence.Repository;
using PT.Dasigno.BLL.Persistence.Repository.Base;
using PT.Dasigno.BLL.Persistence.Services;

namespace PT.Dasigno.API.Extensions.ServiceCollection
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositorios genéricos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Repositorios específicos
            services.AddTransient<IUsersRepository, UsersRepository>();

            // Servicios
            services.AddTransient<IUsersServices, UsersServices>();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            return services;
        }
    }
}
