namespace ContactBook.Interfaces
{
    public interface IFileService
    {
        public bool SaveToFile(string filePath, string content);

        public string GetContentFromFile(string filepath);


    }
}
