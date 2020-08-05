using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Topshelf;

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
                //var config = GetJsonConfig();
                //Console.WriteLine("json-config: " + config["key1"]);//Example how to access configurations.

                //var messageService = new MessageService(logger);
                var exitCode = HostFactory.Run(x =>
                {
                    x.Service<MessageService>(s =>
                    {
                        s.ConstructUsing(messageService => new MessageService(logger));
                        s.WhenStarted(messageService => messageService.Start());
                        s.WhenStopped(messageService => messageService.Stop());
                    });

                    x.RunAsLocalSystem();

                    x.SetServiceName("MyMessageService");
                    x.SetDisplayName("My Message Service");
                    x.SetDescription("This is my test.");

                });

                int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
                Environment.ExitCode = exitCodeValue;

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
