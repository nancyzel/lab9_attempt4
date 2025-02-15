using lab9;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace lab9_tests;

[TestClass]
public class TestProgramGetAmplitude
{
    [TestMethod]
    public void TestCountArrayTemperatureAmplitude()
    {
        //Arrange
        double expectedAmplitude = 10.1;
        //Act
        Tuple<double, int, int>[] actualWeatherContents =
        {
            Tuple.Create(10.5, 60, 760),
            Tuple.Create(16.5, 70, 770),
            Tuple.Create(20.6, 80, 780),
        };
        WeatherObjectsCollection actualWeatherObjects = new WeatherObjectsCollection(3, actualWeatherContents);
        double actualAmplitude = lab9.Program.CountArrayTemperatureAmplitude(actualWeatherObjects);
        //Assert
        Assert.AreEqual(expectedAmplitude, actualAmplitude, 0.00000001);
    }
}
