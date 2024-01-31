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
        string filePath = @"C:\Users\Jonas\source\repos\ContactBookAssignment\ContactBook\test.txt";
        string content = "Test content";


        //Act
        bool result = fileService.SaveToFile(filePath, content);

        //Assert
        Assert.True(result);
    
    }
 
}
