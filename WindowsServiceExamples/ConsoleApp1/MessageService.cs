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
        private static Thread _thread1;

        public MessageService(ILogger logger)
        {
            _logger = logger;

            _thread1 = new Thread(MainLogging);
            _thread1.IsBackground = true;
        }

        public bool Start()
        {
            _logger.Information(">> Start called.");
            _logger.Information(">> Thread started.");
            _thread1.Start();

            return true;
            
        }

        public void Stop()
        {
            _logger.Information(">> Stop called.");
            _running = false;
            Thread.Sleep(1000); // Give time to thread to finish it work before calling stop.
            
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
            _logger.Information(">>After while loop in MainLogging().");
            Console.WriteLine(">>After while loop in MainLogging().");
        }

    }
}
