using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
//System.Timers is the thread safe Timer class.

namespace ConsoleApp1
{
    public class MessageService
    {
        private static ILogger _logger;
        private static bool _running;
        public MessageService(ILogger logger)
        {
            _logger = logger;            
        }

        public bool Start()
        {
            _logger.Information(">> Start called.");
            _logger.Information(Directory.GetCurrentDirectory().ToString());
            //Console.WriteLine(">>Start called.");

            //Thread thread1 = new Thread(MainLogging);
            //thread1.IsBackground = true; 
            //thread1.Start();

            //_logger.Information(">> return true!.");
            //Console.WriteLine(">> return true!.");
            return true;
            
        }

        public void Stop()
        {
            _logger.Information(">> Stop called.");
            _running = false;
        }

        public static void MainLogging()
        {
            _running = true;
            int iterator = 0;

            while (_running)
            {
                Thread.Sleep(1000);
                _logger.Information(">>Iteration: " + iterator);
                Console.WriteLine(">>Iteration: " + iterator);
                iterator++;
            }
            _logger.Information(">>After while loop in Start().");
            Console.WriteLine(">>After while loop in Start().");
        }

    }
}
