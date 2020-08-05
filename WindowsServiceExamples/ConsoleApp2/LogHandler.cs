using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class LogHandler
    {
        private readonly string _pathLogDirectory = @"C:\Temp";//Directory will be created in the same location as the executable file.
        private string _pathLogFile;
        public Logger Logger { get; set; }

        public LogHandler()
        {
            CreateLogFile();
            CreateLogger();
        }

        //Create a log file with a timestamp in the filename and a standard header in that file.
        private void CreateLogFile()
        {
            System.IO.Directory.CreateDirectory(_pathLogDirectory);
            var appStartDatetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");//e.g. 2020-08-05 13:49 -> 20200805_1346
            string fileName = appStartDatetime + " - Log.txt";
            _pathLogFile = System.IO.Path.Combine(_pathLogDirectory, fileName);
            var logHeader = "### LOG ### \n";
            System.IO.File.WriteAllText(_pathLogFile, logHeader);
        }

        //Create a logger from Serilog.Core.Logger library.
        private void CreateLogger()
        {
            Logger = new LoggerConfiguration().WriteTo.File(_pathLogFile).CreateLogger();
        }

    }
}
