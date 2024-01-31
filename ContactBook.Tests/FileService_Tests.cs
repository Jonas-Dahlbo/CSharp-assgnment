using ContactBook.Interfaces;
using ContactBook.Services;
using Moq;

namespace ContactBook.Tests;

public class FileService_Tests
{
    [Fact]

    public void SaveToFileShould_ReturnFalse_IfFilePathDoesNotExist()
    {
        //Arrange
        IFileService fileService = new FileServices();
        string filePath = $@"c:\{Guid.NewGuid()}\test.txt";
        string content = "Test content";


        //Act
        bool result = fileService.SaveToFile(filePath, content);

        //Assert
        Assert.False(result);

    }

    [Fact]

    public void SaveToFileShould_SaveContentToFile_ThenReturnTrue() 
    {
        //Arrange
        IFileService fileService = new FileServices();
        string filePath = @"..\..\test.txt";
        string content = "Test content";


        //Act
        bool result = fileService.SaveToFile(filePath, content);

        //Assert
        Assert.True(result);
    
    }

    [Fact]

    public void GetContentFromFileShould_ReadAFile_ThenReturnTheFileContent()
    {
        //Arrange
        IFileService fileService = new FileServices();
        string filePath = @"..\..\..\..\ContactBook\Repositories\ContactBook.json";

        //Act
        string result = fileService.GetContentFromFile(filePath);

        //Assert
        Assert.NotEmpty(result);
    }

    [Fact]

    public void GetContentFromFileShould_FailToReadAFile_ThenReturnThenReturnNull()
    {
        //Arrange
        IFileService fileService = new FileServices();
        string filePath = $@"c:\{Guid.NewGuid()}\test.txt";

        //Act
        string result = fileService.GetContentFromFile(filePath);

        //Assert
        Assert.Null(result);
    }
}
