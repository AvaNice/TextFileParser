using Serilog;
using System.IO;

namespace TextFileParser
{
    class TextParserApp
    {
        private readonly FileWorker fileWorker = new FileWorker();
        private readonly TextParserUI userInterface = new TextParserUI();

        public void Start()
        {
            RunMode(userInterface.GetUserMode());

            if(userInterface.IsOneMore())
            {
                Start();
            }
        }

        private void RunMode(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.CountLine:
                    string pathForCount = userInterface.GetUserPath();
                    string desiredLine = userInterface.GetUserParameter(TextMessages.DESIRED_LINE);
                    int entries = CountLine(pathForCount, desiredLine);

                    userInterface.ShowResult(entries.ToString(), TextMessages.ENTRIES);
                    break;

                case UserMode.ReplaceLine:
                    string pathForReplace = userInterface.GetUserPath();
                    string oldline = userInterface.GetUserParameter(TextMessages.OLD_LINE);
                    string newLine = userInterface.GetUserParameter(TextMessages.NEW_LINE);

                    ReplaceLine(pathForReplace, oldline, newLine);
                    userInterface.ShowResult("Jobs done");
                    break;

                default:
                    Log.Logger.Information($"TextParserApp.RunMode({userMode}) Default");
                    break;
            }
        }

        public int CountLine(string path, string line)
        {
            try
            {
                return fileWorker.CountLineEntries(path, line);
            }

            catch (IOException ex)
            {
                Log.Logger.Error($"{ex.Message} TextParserApp.CountLine");
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
                Log.Logger.Error($"{ex.Message} TextParserApp.ReplaceLine");
                throw;
            }
        }
    }
}
