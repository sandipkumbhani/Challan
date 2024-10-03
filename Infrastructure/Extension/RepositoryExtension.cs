using Application.Interface;
using Application.Providers;
using Domain.Interface;
using Infrastructure.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extension
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddEfcoreInfrastrucureService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IFollowRepo, FollowRepo>();
            services.AddScoped<IQuotationRepo, QuotationRepo>();
            services.AddScoped<ILoginRepo, LoginRepo>();
            services.AddScoped<IAttachmentRepo, AttachmentRepo>();
            return services;
        }
    }
}
