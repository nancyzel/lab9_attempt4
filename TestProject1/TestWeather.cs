using lab9;
namespace lab9_tests
{
    [TestClass]
    public sealed class TestWeather
    {
        [TestMethod]
        public void TestGetObjectsQuantity()
        {
            //Arrange
            int expectedObjectsQuantity = 2;
            //Act
            Weather currentWeather1 = new Weather(25.5, 45, 770);
            Weather currentWeather2 = new Weather(25, 45, 770);
            int actualObjectsQuantity = Weather.GetObjectsQuantity();
            //Assert
            Assert.AreEqual(expectedObjectsQuantity, actualObjectsQuantity);
        }

        [TestMethod]
        public void TestConstructorAllParameters()
        {
            //Arrange
            double expectedTemperature = 25.5;
            int expectedHumidity = 45;
            int expectedPressure = 770;
            //Act
            Weather currentWeather = new Weather(25.5, 45, 770);
            //Assert
            Assert.AreEqual(expectedTemperature, currentWeather.Temperature);
            Assert.AreEqual(expectedHumidity, currentWeather.Humidity);
            Assert.AreEqual(expectedPressure, currentWeather.Pressure);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConstructorAllParametersWithExeptionNegativeHumidity()
        {
            Weather currentWeather1 = new Weather(25.5, -45, 770);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConstructorAllParametersWithExeptionUnlimitedHumidity()
        {
            Weather currentWeather2 = new Weather(25.5, 101, 770);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestConstructorAllParametersWithExeptionnegativePressure()
        {
            Weather currentWeather3 = new Weather(25.5, 0, -770);
        }

        [TestMethod]
        public void TestConstructorTemperatureParameter()
        {
            //Arrange
            Weather expectedWeather = new Weather(35.7, 40, 700);
            //Act
            Weather currentWeather = new Weather(35.7);
            //Assert
            Assert.AreEqual(expectedWeather, currentWeather);
        }

        [TestMethod]
        public void TestConstructorAnotherObjectParameter()
        {
            //Arrange
            Weather expectedWeather = new Weather(35.7, 40, 700);
            //Act
            Weather currentWeather = new Weather(expectedWeather);
            //Assert
            Assert.AreEqual(expectedWeather, currentWeather);
        }

        [TestMethod]
        public void TestConstructorNoParameters()
        {
            //Arrange
            Weather expectedWeather = new Weather(15.5, 50, 760);
            //Act
            Weather currentWeather = new Weather();
            //Assert
            Assert.AreEqual(expectedWeather, currentWeather);
        }

        [TestMethod]
        public void TestShowWeatherConditions()
        {
            //Arrange
            double expectedTemperature = 25.5;
            int expectedHumidity = 45;
            int expectedPressure = 770;
            //Act
            Weather currentWeather = new Weather(25.5, 45, 770);
            currentWeather.ShowWeatherConditions(out double actualTemperature, out int actualHumidity, out int actualPressure);
            //Assert
            Assert.AreEqual(expectedTemperature, actualTemperature);
            Assert.AreEqual(expectedHumidity, actualHumidity);
            Assert.AreEqual(expectedPressure, actualPressure);
        }

        [TestMethod]
        public void TestGetDewPointClassMethod()
        {
            //Arrange
            double expectedTemperature = 25.5;
            int expectedHumidity = 45;

            const double a = 17.27;
            const double b = 237.7;
            double dewPointCoefficient = a * expectedTemperature / (b + expectedTemperature) + Math.Log((double)expectedHumidity / 100);
            double expectedDewPoint = Math.Round(b * dewPointCoefficient / (a - dewPointCoefficient), 4);
            //Act
            Weather currentWeather = new Weather(25.5, 45, 770);
            double actualdewPoint = currentWeather.GetDewPointClassMethod(out double actualTemperature, out int actualHumidity);
            //Assert
            Assert.AreEqual(expectedTemperature, actualTemperature);
            Assert.AreEqual(expectedHumidity, actualHumidity);
            Assert.AreEqual(expectedDewPoint, actualdewPoint);
        }

        [TestMethod]
        public void TestGetDewPointStaticMethod()
        {
            //Arrange
            double expectedTemperature = 25.5;
            int expectedHumidity = 45;

            const double a = 17.27;
            const double b = 237.7;
            double dewPointCoefficient = a * expectedTemperature / (b + expectedTemperature) + Math.Log((double)expectedHumidity / 100);
            double expectedDewPoint = Math.Round(b * dewPointCoefficient / (a - dewPointCoefficient), 4);
            //Act
            Weather currentWeather = new Weather(25.5, 45, 770);
            double actualdewPoint = Weather.GetDewPointStaticMethod(currentWeather, out double actualTemperature, out int actualHumidity);
            //Assert
            Assert.AreEqual(expectedTemperature, actualTemperature);
            Assert.AreEqual(expectedHumidity, actualHumidity);
            Assert.AreEqual(expectedDewPoint, actualdewPoint);
        }

        [TestMethod]
        public void TestOperatorNegative()
        {
            //Arrange
            Weather expectedWeather = new Weather(-40);
            //Act
            Weather actualWeather = new Weather(40);
            //Assert
            Assert.AreEqual(-expectedWeather, actualWeather);
        }

        [TestMethod]
        public void TestOperatorOppositeTrue()
        {
            //Arrange
            bool expectedResultOppositeWeather = true;
            //Act
            Weather actualWeather = new Weather(40, 88, 760);
            bool actualResultOppositeWeather = !actualWeather;
            //Assert
            Assert.AreEqual(expectedResultOppositeWeather, actualResultOppositeWeather);
        }

        [TestMethod]
        public void TestOperatorOppositeFalse()
        {
            //Arrange
            bool expectedResultOppositeWeather = false;
            //Act
            Weather actualWeather = new Weather(40, 78, 760);
            bool actualResultOppositeWeather = !actualWeather;
            //Assert
            Assert.AreEqual(expectedResultOppositeWeather, actualResultOppositeWeather);
        }

        [TestMethod]
        public void TestOperatorExplicitFalseResult()
        {
            //Arrange
            bool expectedResult = false;
            //Act
            Weather actualWeather = new Weather(40, 78, 760);
            bool actualResult = (bool)actualWeather;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOperatorExplicitTrueResult()
        {
            //Arrange
            bool expectedResult = true;
            //Act
            Weather actualWeather = new Weather(40, 78, 770);
            bool actualResult = (bool)actualWeather;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOperatorMinus()
        {
            //Arrange
            Weather expectedWeather = new Weather(45.4543, 78, 760);
            //Act
            Weather newWeather = new Weather(40, 78, 760);
            Weather actualWeather = newWeather - (-5.4543);
            //Assert
            Assert.AreEqual(expectedWeather, actualWeather);
        }

        [TestMethod]
        public void TestOperatorMultiplication()
        {
            //Arrange
            Weather expectedWeather = new Weather(45, 70, 760);
            //Act
            Weather newWeather = new Weather(36, 56, 608);
            Weather actualWeather = newWeather * 25;
            //Assert
            Assert.AreEqual(expectedWeather, actualWeather);
        }
    }
}
