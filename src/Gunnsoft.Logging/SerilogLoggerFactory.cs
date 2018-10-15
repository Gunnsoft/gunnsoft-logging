using Microsoft.Extensions.Logging;
using Serilog.Debugging;
using Serilog.Extensions.Logging;

namespace Gunnsoft.Logging
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly SerilogLoggerProvider _provider;

        public SerilogLoggerFactory
        (
            Serilog.ILogger logger = null,
            bool dispose = false
        )
        {
            _provider = new SerilogLoggerProvider
            (
                logger,
                dispose
            );
        }

        public void Dispose() => _provider.Dispose();

        public ILogger CreateLogger
        (
            string categoryName
        )
        {
            return _provider.CreateLogger(categoryName);
        }

        public void AddProvider
        (
            ILoggerProvider provider
        )
        {
            SelfLog.WriteLine("Ignoring logger provider {0}", provider);
        }
    }
}
