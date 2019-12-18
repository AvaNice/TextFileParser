using Serilog;
using System.IO;

namespace TextFileParser
{
    public class FileWorker
    {
        /// <summary>
        /// Count all entries of line in file by path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public int CountLineEntries(string path, string line)
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

                        while (thisLine.Contains(line))
                        {
                            numberOfEntries++;
                            
                            int buff = thisLine.IndexOf(line);

                            thisLine = thisLine.Remove(0, buff + line.Length);
                        }
                    }

                    return numberOfEntries;
                }
            }
            catch (IOException ex)
            {
                Log.Logger.Error($"{ex.Message} FileWorker.CountLineEntries");

                throw;
            }
        }

        /// <summary>
        /// Replase oldLine to newLine in file by path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="oldLine"></param>
        /// <param name="newLine"></param>
        public void ReplaseLine(string path, string oldLine, string newLine)
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

                    if (thisLine.Contains(oldLine))
                    {
                        thisLine = thisLine.Replace(oldLine, newLine);

                        writer.WriteLine(thisLine);
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
                Log.Logger.Error($"{ex.Message} FileWorker.ReplaseLine");

                throw ex;
            }
        }
    }
}
