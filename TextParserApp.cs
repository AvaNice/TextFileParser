using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileParser
{
    class TextParserApp
    {
        private readonly FileWorker fileWorker = new FileWorker();
        private readonly TextParserUI UI = new TextParserUI();

        public void Start()
        {

            RunMode(UI.GetUserMode());

            Start();
        }

        private void RunMode(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.CountLine:

                    string pathForCount = UI.GetUserPath();
                    string desiredLine = UI.GetUserParameter(TextMessages.DESIRED_LINE);
                    int entries = CountLine(pathForCount, desiredLine);

                    UI.ShowResult(entries.ToString(), TextMessages.ENTRIES);

                    break;

                case UserMode.ReplaceLine:

                    string pathForReplace = UI.GetUserPath();
                    string oldline = UI.GetUserParameter(TextMessages.OLD_LINE);
                    string newLine = UI.GetUserParameter(TextMessages.NEW_LINE);

                    ReplaceLine(pathForReplace, oldline, newLine);

                    UI.ShowResult("Jobs done");

                    break;

                default:

                    //TODO log

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
