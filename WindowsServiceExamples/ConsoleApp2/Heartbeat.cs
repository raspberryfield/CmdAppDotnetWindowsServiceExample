using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace ConsoleApp2
{
    class Heartbeat
    {
        private readonly Timer _timer;
        private ILogger _logger;

        public Heartbeat(ILogger logger)
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
            _logger = logger;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\Heartbeat.txt", lines);
        }
        public void Start()
        {
            _timer.Start();
            _logger.Information(">> Started!");
        }

        public void Stop()
        {
            _timer.Stop();
            _logger.Information(">> Stopped!");
        }
    }
}
