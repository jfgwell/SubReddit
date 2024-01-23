﻿using SubRedditLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reddit.Controllers;

namespace SubReddit
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var ServiceProvider = BuildServiceProvider();

            var loggerFactory = LoggerFactory.Create(
            builder => builder
                        // add console as logging target
                        .AddConsole()
                        // add debug output as logging target
                        .AddDebug()
                        // set minimum level to log
                        .SetMinimumLevel(LogLevel.Debug)
        );

            // create a logger
            var logger = loggerFactory.CreateLogger<Program>();



            // Interval I = new Interval();
            // I.Setup();
            // I.Run();
            try
            {
                ServiceProvider.GetRequiredService<IInterval>().Setup();
                logger.LogInformation("Setup Complete (Console)");
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }


            try
            {
                ServiceProvider.GetRequiredService<IInterval>().Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }


        }

        private static IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IInterval,Interval>()
                .BuildServiceProvider();

        }
    }
}