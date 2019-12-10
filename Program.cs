using System;
using System.Text;

namespace TextFileParser
{
    class Program
    {

        static void Main(string[] args)
        {
            RunMode runMode;
            FileWorker fileWorker = new FileWorker();
            TextParserUI userInterface = new TextParserUI();
            TextParserApp app = new TextParserApp(fileWorker);
            
            try
            {
                runMode = userInterface.GetUserMode();


                app.Start();
            }
            catch (Exception ex)
            {
                //TODO log
            }
        }
    }
}
