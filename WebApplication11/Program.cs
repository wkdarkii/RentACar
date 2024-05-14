using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Entitys.Context;
using WebApplication11.Session;

namespace WebApplication11
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Razor view engine configuration /ADMIN YOL AYARLARI
			builder.Services.Configure<RazorViewEngineOptions>(options =>
			{
				options.AreaViewLocationFormats.Clear();
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Admin/{2}/Views/Shared/{0}.cshtml");
				options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
			});

			// Add services to the container.
			builder.Services.AddScoped<SessionAuthorizationFilter>();

            builder.Services.AddSession();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
					.AddCookie(options =>
					{
						options.LoginPath = "/Account/Login"; // Redirect to login page when not authenticated
						options.LogoutPath = "/Account/Logout"; // Redirect to logout page when user logs out
						options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect to access denied page when user is not authorized
						options.Cookie.Name = "YourAppCookieName"; // Cookie name for session
						options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Session timeout
					});

			builder.Services.AddDbContext<OtelContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("OtelContext"));
            });

            builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession();
			app.UseAuthorization();
            app.UseAuthorization();
            app.UseAuthentication(); // Add this line for authentication

            // Controller routing
            app.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");


            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
