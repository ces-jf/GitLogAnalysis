
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Repositories;
using GitLogAnalysis.Core.Aggregates.GitAgg.Interfaces.Services;
using GitLogAnalysis.Core.Aggregates.GitAgg.Services;
using GitLogAnalysis.Core.SharedKernel.Interfaces.UoW;
using GitLogAnalysis.Infra.Data;
using GitLogAnalysis.Infra.Data.Repositories;
using GitLogAnalysis.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitLogAnalysis.CrossCutting.IoC
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Entity Framework
            services.AddScoped<DataContext>();

            services.AddDbContext<DataContext>(x =>
                x.UseMySql(configuration.GetConnectionString("MySQLConnection")));

            // Unity Of Work
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            // Services
            services.AddScoped<IReleaseDataService, ReleaseDataService>();
            services.AddScoped<IProjectService, ProjectService>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IProfileService, ProfileService>();
            //services.AddScoped<IFunctionalityService, FunctionalityService>();
            //services.AddScoped<IEventService, EventService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<IEventTypeService, EventTypeService>();
            //services.AddScoped<ISubscriptionService, SubscriptionService>();

            // Repositories
            services.AddScoped<IReleaseDataRepository, ReleaseDataRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            //services.AddScoped<IProfileRepository, ProfileRepository>();
            //services.AddScoped<IFunctionalityRepository, FunctionalityRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
            //services.AddScoped<ICityRepository, CityRepository>();
            //services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            //services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            // Validators
            //services.AddTransient<IValidator<EventForRegisterDto>, EventValidator>();
            //services.AddTransient<IValidator<EventForEditDto>, EventEditValidator>();
            //services.AddTransient<IValidator<ProfileForRegisterDto>, ProfileValidator>();
            //services.AddTransient<IValidator<ProfileForEditDto>, ProfileEditValidator>();

            // Configuration


        }
    }
}
