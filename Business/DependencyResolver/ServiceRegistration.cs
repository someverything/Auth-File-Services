using Business.ValidationRules.FluentValidation;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddHttpClient();

            ValidatorOptions.Global.LanguageManager = new CustomLangManager();

            #region FluentEmail
            var emailSettings = configuration.GetSection("EmailSettings");
            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["Host"];
            var port = emailSettings.GetValue<int>("Port");
            var username = emailSettings["Username"];
            var password = emailSettings["Password"];
            services.AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(host, port, username, password);
            #endregion
        }
    }
}
