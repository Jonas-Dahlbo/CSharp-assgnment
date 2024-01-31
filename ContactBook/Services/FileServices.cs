using ContactBook.Interfaces;
using System.Diagnostics;

namespace ContactBook.Services
{
    public class FileServices : IFileService
    {
        /// <summary>
        /// Saves the provided content to a file
        /// </summary>
        /// <param name="filePath">The path to the file that is to be saved</param>
        /// <param name="content">The content that is to be saved to the file</param>
        /// <returns>True if the file is saved, otherwise False</returns>
        public bool SaveToFile(string filePath, string content)
        {
            try
            {
                using var sw = new StreamWriter(filePath);
                sw.WriteLine(content);
                return true;
            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        /// <summary>
        /// Reads the file and returns it's content as a string.
        /// </summary>
        /// <param name="filePath">The path to the file that is to be read</param>
        /// <returns>Returns the content of a file as a string</returns>
        public string GetContentFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using var sr = new StreamReader(filePath);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
