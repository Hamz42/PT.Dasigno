using Microsoft.EntityFrameworkCore;
using PT.Dasigno.DAL.Context.ContextDasigno;

namespace PT.Dasigno.API.Extensions.ServiceCollection
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<dbContextDasigno>(options => {
                options.UseLazyLoadingProxies()
                       .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
