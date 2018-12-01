using System;
using System.IO;

namespace Common
{
    public class FileProcessor
    {
        public void ReadFilePerLine(string path, Action<string> action)
        {
            foreach (string line in File.ReadLines(path))
            {
                action(line);
            }
        }

        public void ReadFilePerLine(string path, int lineNumber, Action<int, string> action)
        {
            foreach (string line in File.ReadLines(path))
            {
                action(lineNumber, line);
            }
        }

        public string ReadFileToEnd(string path)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }

    }
}
