using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleApp1 - Testing Topshelf!");

            var logger = new LogHandler().Logger;
            logger.Information(">> Application started.");

            try
            {
                var config = GetJsonConfig();
                Console.WriteLine("json-config: " + config["key1"]);//Example how to access configurations.
            }
            catch (Exception e){
                logger.Error(e.ToString());
                Console.WriteLine(e.ToString());
            }
            

        }

        static IConfigurationRoot GetJsonConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
            return config;
        }


    }
}
