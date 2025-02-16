using lab9;
using Microsoft.Testing.Platform.OutputDevice;
namespace lab9_tests;

[TestClass]
public class TestWeatherObjectsCollection
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

    [TestMethod]
    public void TestCreateCollectionUsingKeyboard()
    {
        //Arrange
        int expectedObjectsQuantity = 3;
        Weather expectedWeather1 = new Weather(15.5, 60, 760);
        Weather expectedWeather2 = new Weather(16.5, 70, 770);
        Weather expectedWeather3 = new Weather(15.6, 80, 780);
        //Act
        Tuple<double, int, int>[] actualWeatherContents =
        {
            Tuple.Create(15.5, 60, 760),
            Tuple.Create(16.5, 70, 770),
            Tuple.Create(15.6, 80, 780),
        };
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(3, actualWeatherContents);
        int actualObjectsQuantity = actualWeatherObjects.Length;
        //Assert
        Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        Assert.AreEqual(expectedWeather1, actualWeatherObjects[0]);
        Assert.AreEqual(expectedWeather2, actualWeatherObjects[1]);
        Assert.AreEqual(expectedWeather3, actualWeatherObjects[2]);
    }

    [TestMethod]
    public void TestCreateCollectionUsingAnotherObject()
    {
        //Arrange
        int expectedObjectsQuantity = 3;
        Tuple<double, int, int>[] expectedWeatherContents =
        {
            Tuple.Create(15.5, 60, 760),
            Tuple.Create(16.5, 70, 770),
            Tuple.Create(15.6, 80, 780),
        };
        WeatherObjectsCollection expectedWeatherObjects = new WeatherObjectsCollection(3, expectedWeatherContents);
        //Act
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(expectedWeatherObjects);
        int actualObjectsQuantity = actualWeatherObjects.Length;
        //Assert
        Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        for (int i = 0; i < actualWeatherObjects.Length; i++)
        {
            Assert.AreEqual(expectedWeatherObjects[i], actualWeatherObjects[i]);
        }
    }

    [TestMethod]
    public void TestGetCollectionElements()
    {
        //Arrange
        int expectedObjectsQuantity = 3;
        Tuple<double, int, int>[] expectedWeatherContents =
        {
            Tuple.Create(15.5, 60, 760),
            Tuple.Create(16.5, 70, 770),
            Tuple.Create(15.6, 80, 780),
        };
        WeatherObjectsCollection expectedWeatherObjects = new WeatherObjectsCollection(3, expectedWeatherContents);
        //Act
        Tuple<double, int, int>[] actualWeatherContents = expectedWeatherObjects.GetCollectionElements();
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(3, actualWeatherContents);
        int actualObjectsQuantity = actualWeatherObjects.Length;
        //Assert
        Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        for (int i = 0; i < actualWeatherObjects.Length; i++)
        {
            Assert.AreEqual(expectedWeatherObjects[i], actualWeatherObjects[i]);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestIndexatorGetOutOfRange()
    {
        WeatherObjectsCollection weatherObjects = new WeatherObjectsCollection(3);
        Weather currentWeather1 = weatherObjects[-1];
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestIndexatorSetOutOfRange()
    {
        WeatherObjectsCollection weatherObjects = new WeatherObjectsCollection(3);
        weatherObjects[-1] = new Weather();
    }


    [TestMethod]
    public void TestIndexatorSet()
    {
        //Arrange
        Weather expectedWeather = new Weather();
        //Act
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(3);
        actualWeatherObjects[0] = new Weather();
        //Assert
        Assert.AreEqual(expectedWeather, actualWeatherObjects[0]);
    }
}
