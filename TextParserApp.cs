using Serilog;
using System.IO;

namespace TextFileParser
{
    public class TextParserApp
    {
        private readonly FileWorker _fileWorker = new FileWorker();
        private readonly TextParserUI _userInterface = new TextParserUI();

        public void Start()
        {
            RunMode(_userInterface.GetUserMode());

            if (_userInterface.IsOneMore())
            {
                Start();
            }
        }

        private void RunMode(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.CountLine:
                    string pathForCount = _userInterface.GetUserPath();
                    string desiredLine = _userInterface.GetUserParameter(TextMessages.DESIRED_LINE);
                    int entries = CountLine(pathForCount, desiredLine);

                    _userInterface.ShowResult(entries.ToString(), TextMessages.ENTRIES);
                    break;

                case UserMode.ReplaceLine:
                    string pathForReplace = _userInterface.GetUserPath();
                    string oldline = _userInterface.GetUserParameter(TextMessages.OLD_LINE);
                    string newLine = _userInterface.GetUserParameter(TextMessages.NEW_LINE);

                    ReplaceLine(pathForReplace, oldline, newLine);
                    _userInterface.ShowResult("Jobs done");
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
                return _fileWorker.CountLineEntries(path, line);
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
                _fileWorker.ReplaseLine(path, oldLine, newLine);
            }
            catch (IOException ex)
            {
                Log.Logger.Error($"{ex.Message} TextParserApp.ReplaceLine");
                throw;
            }
        }
    }
}
