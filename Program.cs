using Serilog;
using System;

namespace TextFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            TextParserApp _app = new TextParserApp();
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            try
            {
                _app.Start();
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message} Main");
            }
        }
    }
}
