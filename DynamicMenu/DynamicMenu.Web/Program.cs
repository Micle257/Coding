// -----------------------------------------------------------------------
//  <copyright file="Program.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;

    /// <summary> Represents a main enter point of the web application. </summary>
    public class Program
    {
        /// <summary> Invokes when the application starts. </summary>
        /// <param name="args"> The arguments. </param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseApplicationInsights()
                    .Build();

            host.Run();
        }
    }
}