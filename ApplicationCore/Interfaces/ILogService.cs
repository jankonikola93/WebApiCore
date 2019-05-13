using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ILogService
    {
        void WriteLog(string message, string logFileName);
    }
}
