﻿using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Thingy;

namespace WebApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //https://github.com/aspnet/StaticFiles/blob/dev/src/Microsoft.AspNetCore.StaticFiles/DirectoryBrowserServiceExtensions.cs
            //services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //https://github.com/aspnet/StaticFiles
            //Order matters.
            //app.UseDirectoryBrowser();

            /*Will default to index.html*/
            //app.UseFileServer(); 

            app.Run(async (context) =>
            {
                var stuff = new Stuff();

                var sb = new StringBuilder();
                sb.AppendLine($"App is running in mode: [{env.EnvironmentName} it's something [{Configuration["Message"]}].]");
                sb.AppendLine(stuff.Message);

                await context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}