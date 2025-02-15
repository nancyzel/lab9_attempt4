using lab9;
using Microsoft.Testing.Platform.OutputDevice;
namespace lab9_tests;

[TestClass]
public class Test2
{
    [TestMethod]
    public void TestCreateBasicCollection()
    {
        //Arrange
        int expectedObjectsQuantity = 10;
        double expectedTemperature = 15.5;
        int expectedHumidity = 50;
        int expectedPressure = 760;
        //Act
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection();
        int actualObjectsQuantity = actualWeatherObjects.Length;
        //Assert
        Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        for (int i = 0; i < actualObjectsQuantity; i++)
        {
            Weather expectedWeather = new Weather(expectedTemperature, expectedHumidity, expectedPressure);
            Assert.AreEqual(expectedWeather, actualWeatherObjects[i]);
        }
    }

    [TestMethod]
    public void TestCreateCollectionRandomWay()
    {
        //Arrange
        int expectedObjectsQuantity = 5;
        //Act
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(5);
        int actualObjectsQuantity = actualWeatherObjects.Length;
        //Assert
        Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        for (int i = 0; i < actualObjectsQuantity; i++)
        {
            Assert.IsNotNull(actualWeatherObjects[i]);
            Assert.IsInstanceOfType(actualWeatherObjects[i], typeof(Weather));
        }
    }
}
