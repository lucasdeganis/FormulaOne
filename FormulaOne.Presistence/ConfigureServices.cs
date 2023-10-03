using FormulaOne.Presistence.Contexts;
using FormulaOne.Presistence.Interceptors;
using FormulaOne.Presistence.Interfaces;
using FormulaOne.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormulaOne.Presistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("FormulaOneDBConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IPersonsRepository, PersonsRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<IDriversRepository, DriversRepository>();

            return services;
        }
    }
}
