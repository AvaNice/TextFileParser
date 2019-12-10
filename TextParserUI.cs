using Serilog;
using System;
using System.IO;

namespace TextFileParser
{
    class TextParserUI
    {
        public UserMode GetUserMode()
        {
            ShowHelp();

            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case TextMessages.COUNT_LINE_SELECT:
                    return UserMode.CountLine;

                case TextMessages.REPLACE_LINE_SELECT:
                    return UserMode.ReplaceLine;

                default:
                    Log.Logger.Information($"UI.Default({userInput})");

                    return GetUserMode();
            }
        }

        public void ShowHelp()
        {
            Console.WriteLine(TextMessages.HELP);
        }

        public string GetUserPath()
        {
            Console.Write($"{TextMessages.ENTER} {TextMessages.PATH} = ");

            string input = Console.ReadLine();

            if (File.Exists(input))
            {
                return input;
            }

            Console.WriteLine(TextMessages.FILE_DONT_EXIST);

            return GetUserPath();
        }

        public string GetUserParameter(string paramName)
        {
            Console.Write($"{TextMessages.ENTER} {paramName} = ");

            return Console.ReadLine(); ;
        }

        public void ShowResult(params string[] results)
        {
            foreach (var item in results)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        public bool IsOneMore()
        {
            string input;
            bool result;

            Console.WriteLine(TextMessages.NEED_MORE);
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case TextMessages.YES:
                case TextMessages.YES_SECOND:
                    result = true;
                    break;

                case TextMessages.NO:
                case TextMessages.NO_SECOND:
                    result = false;
                    break;

                default:
                    Log.Logger.Information($"UI default. User input {input}");
                    Console.WriteLine(TextMessages.CANT_READ_MODE);

                    return IsOneMore();
            }

            return result;
        }
    }
}
