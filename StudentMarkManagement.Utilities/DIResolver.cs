using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentMarkManagement.Core.IRepositories;
using StudentMarkManagement.Core.IServices;
using StudentMarkManagement.Services.Services;
using StudentMarkManagement.Resources.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Utilities
{
    public static class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IStudentServices, StudentService>();

            #endregion
            #region Repository

            services.AddScoped<IStudentRepositories, StudentRepository>();

            #endregion
        }
    }
}

