using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Logger
{
    public interface ILoggerExtension
    {
        ILogger CreateLogger(string filePath, string name);
    }
    public class LoggerExtension : ILoggerExtension
    {
        public ILogger CreateLogger(string filePath, string name)
        {
            return new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File(@$"{filePath}/{name}-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:HH:mm:ss dd/MM/yyyy} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        }
    }
}
