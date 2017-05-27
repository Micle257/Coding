// -----------------------------------------------------------------------
//  <copyright file="Startup.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web
{
    using System;
    using Infrastructure;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary> Specifies and configures the application's environment. </summary>
    public class Startup
    {
        /// <summary> Initializes a new instance of the <see cref="Startup" /> class. </summary>
        /// <param name="env"> The hosting. </param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", false, true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                    .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary> Gets the configuration root. </summary>
        /// <value> The <see cref="IConfigurationRoot" />. </value>
        [NotNull]
        public IConfigurationRoot Configuration { get; }

        /// <summary> Invoked by CLR, use this to add services to the container. </summary>
        /// <param name="services"> The services. </param>
        public void ConfigureServices([NotNull] IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
                throw new ArgumentException("The appsettings.json doesn't contain the default connection string");

            services.AddDbContext<DataContext>(options => options?.UseSqlServer(connectionString));
        }

        /// <summary> Invoked by CLR, this to configure the HTTP request pipeline. </summary>
        /// <param name="app"> The application builder. </param>
        /// <param name="env"> The hosting. </param>
        /// <param name="loggerFactory"> The logger factory. </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
                       {
                           routes.MapRoute(
                                           "default",
                                           "{controller=Home}/{action=Index}/{id?}");
                       });
        }
    }
}