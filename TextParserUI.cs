﻿using System;
using System.IO;

namespace TextFileParser
{
    class TextParserUI
    {
        public RunMode GetUserMode()
        {
            ShowHelp();

            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case TextMessages.COUNT_LINE_SELECT:
                    return RunMode.CountLine;

                case TextMessages.REPLACE_LINE_SELECT:
                    return RunMode.ReplaceLine;

                default:
                    //TODO log
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
    }
}
