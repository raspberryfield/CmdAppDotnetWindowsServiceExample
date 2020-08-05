using System;
using Topshelf;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! - Heartbeat");

            var logger = new LogHandler().Logger;
            logger.Information(">> Application started.");

            try
            {
                logger.Information(">> In try/catch.");
                var exitCode = HostFactory.Run(x =>
                {
                    x.Service<Heartbeat>(s =>
                    {
                        s.ConstructUsing(heartbeat => new Heartbeat(logger));
                        s.WhenStarted(heartbeat => heartbeat.Start());
                        s.WhenStopped(heartbeat => heartbeat.Stop());
                    });

                    x.RunAsLocalSystem();

                    x.SetServiceName("MyHeartbeatService");
                    x.SetDisplayName("My Heartbeat Service");
                    x.SetDescription("This is my Heartbeat test.");

                });

                int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
                Environment.ExitCode = exitCodeValue;
            }catch(Exception e)
            {
                logger.Error(e.ToString());
            }
        }
    }
}
