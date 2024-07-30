using Microsoft.AspNetCore.DataProtection.Repositories;
using Quartz;
using System.ComponentModel.Design;
using UserManagement.EmailService.Models;
using UserManagement.EmailService.Services;
using UserManagement_IService;
using UserManagementCoreAPI.QuartzJobSchedular;
using UserManagementCoreAPI.Utilities;
using UserManagementInterface;
using UserManagementRepository;
using UserManagementService;

namespace UserManagementCoreAPI.Extention
{
    public static class ServiceRegister
    {
        /// <summary>
        /// register dependencies
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterDependency(this WebApplicationBuilder builder)
        {
            // Configure Email to use the connection string from IOptions
            //builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<HtmlToPdfConverter>();
        }

        /// <summary>
        /// Add email service 
        /// emailConfig contains EmailConfiguration data from appsettings.
        /// add singleton so EmailService get all emailconfig
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterEmailConfiguration(this WebApplicationBuilder builder)
        {            
            var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailService, EmailService>();
        }


        /// <summary>
        /// To send mail from background job Quartz is used 
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterQuartzJobSchedular(this WebApplicationBuilder builder)
        {

            // Add Quartz services
            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                // Create a job and trigger
                q.ScheduleJob<MailSendJobSchedular>(trigger => trigger
                    .WithIdentity("SendMailJobTrigger") // give a job relivent name here
                    .StartNow()
                    .WithCronSchedule(builder.Configuration["QuartzJobSettings:CronExpression"])); // get this from appsettings
            });

            // Add Quartz Hosted Service
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
        
        /// <summary>
        /// register cors
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials());
            });
        }

    }
}
