using LAB5.Services;
using Xunit;

namespace LAB5.Tests;

public class FileHandlerTests
{
    [Fact]
    public void GenerateDrinks_CreatesCorrectAmount()
    {
        var handler = new FileHandler();
        var drinks = handler.GenerateDrinks(50);

        Xunit.Assert.Equal(50, drinks.Count);
    }

    [Fact]
    public void SaveAndLoadDrinks_FilePersistsCorrectly()
    {
        var handler = new FileHandler();
        var drinks = handler.GenerateDrinks(10);
        string path = "test.json";

        handler.SaveDrinksToFile(drinks, path);
        var loaded = handler.LoadDrinksFromFile(path);

        Xunit.Assert.Equal(drinks.Count, loaded.Count);
        File.Delete(path);
    }
}
