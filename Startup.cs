using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace simple
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/Index");
            });
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(o =>
            {
                o.Events = new NegotiateEvents
                {
                    OnAuthenticated = context =>
                    {
                        Console.WriteLine("Startup.cs:OnAuthenticated");
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine("Startup.cs:OnChallenge");
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Startup.cs:OnAuthenticationFailed");
                        Console.WriteLine(context.Exception.Message);
                        return Task.CompletedTask;
                    }
                };
            });

            // services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //     .AddNegotiate(options =>
            //     {
            //         if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //         {
            //             options.EnableLdap(settings =>
            //             {
            //                 settings.Domain = "EXAMPLE.COM";
            //                 settings.MachineAccountName = "machineName";
            //                 settings.MachineAccountPassword = Configuration["Password"]
            //             });
            //         }
            //     });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // No redirection needed
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
