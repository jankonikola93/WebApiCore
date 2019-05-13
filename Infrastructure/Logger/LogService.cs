using ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Logger
{
    public class LogService : ILogService
    {
        private readonly IConfiguration _configuration;
        public LogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void WriteLog(string message, string logFileName)
        {
            var LogDestination = _configuration.GetValue<string>("AppSetings:LogDestination");
            StreamWriter SW;
            if (Directory.Exists(LogDestination))
            {
                var destination = System.IO.Path.Combine(LogDestination, logFileName + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!File.Exists(destination))
                {
                    SW = File.CreateText(destination);
                    SW.Close();
                }

                using (SW = File.AppendText(destination))
                {
                    SW.Write("\r\n\n");
                    SW.WriteLine(DateTime.Now.ToString("dd-MM-yyyy H:mm:ss") + " " + message);
                    SW.Close();
                }
            }
        }
    }
}
