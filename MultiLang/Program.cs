using Application.Interface;
using Application.Providers;
using Domain.Interface;
using Infrastructure.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MultiLang;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Diagnostics.Eventing.Reader;
using Rotativa.AspNetCore;
using Application.Extension;
using Infrastructure.Extension;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Azure.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews()
                        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
            options =>
            {
                options.LoginPath = "/Home/Login";
                options.SlidingExpiration = true;
                
            });
        
        builder.Services.AddMvc();

        builder.Services.AddDbContextPool<AppDBContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        });

        builder.Services.AddApplicationService();
        builder.Services.AddEfcoreInfrastrucureService();
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("home/Error");
        }
        var cookiePolicyOptions = new CookiePolicyOptions
        {
            Secure = CookieSecurePolicy.Always,
            MinimumSameSitePolicy = SameSiteMode.Strict,
        };
        app.UseCookiePolicy(cookiePolicyOptions);
        app.UseStaticFiles();
        app.UseRequestLocalization();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRotativa();

        app.Use(async (context, next) =>
        {
            string cookie = string.Empty;
            if (context.Request.Cookies.TryGetValue("Language", out cookie))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            await next.Invoke();
        });
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=home}/{action=Login}/{id?}");

        app.Run();
    }
}