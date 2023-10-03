using FormulaOne.Application.Business;
using FormulaOne.Application.Interfaces;
using FormulaOne.Application.Validations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IDriversApplication, DriversApplication>();
            services.AddScoped<IPersonsApplication, PersonsApplication>();
            services.AddScoped<ITeamsApplication, TeamsApplication>();

            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<DriversDtoValidator>();

            return services;
        }
    }
}
