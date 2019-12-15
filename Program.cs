using Serilog;
using System;

namespace TextFileParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            TextParserApp app = new TextParserApp();
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            try
            {
                app.Start();
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message} Main");
            }
        }
    }
}
