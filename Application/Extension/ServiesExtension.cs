using Application.Interface;
using Application.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extension
{
    public static  class ServiesExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IResourceServices, ResourceServices>();
            services.AddScoped<IFollowServices, FollowServices>();
            services.AddScoped<IQuotationServices, QuotationServices>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAttachmentServices, AttachmentServices>();
            return services;
        }
    }
}
