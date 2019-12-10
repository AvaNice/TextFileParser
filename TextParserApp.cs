using System.IO;

namespace TextFileParser
{
    class TextParserApp
    {
       
        public TextParserApp(FileWorker fileWorker)
        {

        }

        public void Start(RunMode runMode, string path, string line, string newLine = null)
        {
            switch (runMode)
            {
                case TextFileParser.RunMode.CountLine:

                     path = userInterface.GetUserPath();
                     line = userInterface.GetUserParameter(TextMessages.DESIRED_LINE);
                    int entries = CountLine(path, line);

                    userInterface.ShowResult(entries.ToString(), TextMessages.ENTRIES);

                    break;

                case TextFileParser.RunMode.ReplaceLine:

                    path = userInterface.GetUserPath();
                    line = userInterface.GetUserParameter(TextMessages.OLD_LINE);
                    newLine = userInterface.GetUserParameter(TextMessages.NEW_LINE);

                    ReplaceLine(path, line, newLine);

                    userInterface.ShowResult("Jobs done");

                    break;

                default:

                    //TODO log

                    break;
            }

           // Start();
        }

      
        public int CountLine(string path, string line)
        {
            try
            {
                return fileWorker.CountLineEntries(path, line);
            }

            catch (IOException ex)
            {
                //TODO log
                throw;
            }
        }

        public void ReplaceLine(string path, string oldLine, string newLine)
        {
            try
            {
                fileWorker.ReplaseLine(path, oldLine, newLine);
            }
            catch (IOException ex)
            {
                //TODO log
                throw;
            }
        }
    }
}
