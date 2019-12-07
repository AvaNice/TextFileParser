using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileParser
{
    class Program
    {
        private static readonly TextParserApp _app = new TextParserApp();


        static void Main(string[] args)
        {
            try
            {
                _app.Start();
            }
            catch (Exception ex)
            {
                //TODO log
            }
        }
    }
}
