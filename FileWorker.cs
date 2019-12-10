using System.IO;
using System.Text;

namespace TextFileParser
{
    class FileWorker
    {
        /// <summary>
        /// Count all entries of line in file by path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name=" desiredLine"></param>
        /// <returns></returns>
        public int CountLineEntries(string path, string  desiredLine)
        {
            try
            {

                using (StreamReader reader = new StreamReader(path))
                {
                    string thisLine = string.Empty;
                    int numberOfEntries = 0;

                    while (!reader.EndOfStream)
                    {
                        thisLine = reader.ReadLine();

                        if (thisLine.Contains(desiredLine))
                        {
                            numberOfEntries++;
                        }
                    }

                    return numberOfEntries;
                }

            }
            catch (IOException ex)
            {
                //TODO log
                throw ex;
            }
        }

        /// <summary>
        /// Replase oldLine to newLine in file by path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="oldLine"></param>
        /// <param name="newLine"></param>
        public void ReplaseLine(string path, string oldLine, string newLine, char[] separator = null)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);

                string backupName = $"bacup.txt";
                string thisLine = string.Empty;
                string bufferFile = Path.GetTempFileName();

                DirectoryInfo directory = fileInfo.Directory;

                File.Copy(path, $@"{fileInfo.Directory}\{backupName}", true);

                StreamReader reader = new StreamReader(path);
                StreamWriter writer = new StreamWriter(bufferFile);

                while (!reader.EndOfStream)
                {
                    thisLine = reader.ReadLine();

                    if (thisLine.Contains(thisLine))
                    {
                        if (separator != null)
                        {
                            writer.WriteLine(ReplaseWords(separator, thisLine, oldLine, newLine));
                        }
                        else
                        {
                            thisLine = thisLine.Replace(oldLine, newLine);

                            writer.WriteLine(thisLine);
                        }
                    }
                    else
                    {
                        writer.WriteLine(thisLine);
                    }

                }

                reader.Close();
                writer.Close();

                File.Delete(path);

                File.Move(bufferFile, $@"{directory.FullName}\{fileInfo.Name}");
            }
            catch (IOException ex)
            {
                //TODO log
                throw ex;
            }
        }

        private string ReplaseWords(char[] separator,string line, string oldValue, string newValue)
        {
            StringBuilder result = new StringBuilder();

            string separators = separator.ToString();




            //string[] splitedLine = line.Split(separator);

            //foreach (string word in splitedLine)
            //{
            //    if(word == oldValue)
            //    {
            //        result.Append(newValue);
            //    }
            //    else
            //    {
            //        result.Append(word);
            //    }
            //}

            return result.ToString();
        }
      
    }
}
