namespace lab9
{
    public class Program
    {
        public static double CountArrayTemperatureAmplitude(WeatherObjectsCollection weatherArray)
        {
            double temperatureAmplitude;
            if (OutputData.CheckIfCollectionIsEmpty(weatherArray))
                temperatureAmplitude = -1;
            else
            {
                Weather minimumTemperature = weatherArray[0];
                Weather maximumTemperature = weatherArray[0];
                for (int i = 1; i < weatherArray.Length; i++)
                {
                    if (weatherArray[i] < minimumTemperature)
                    {
                        minimumTemperature = weatherArray[i];
                    }
                    else
                    {
                        if (weatherArray[i] > maximumTemperature)
                        {
                            maximumTemperature = weatherArray[i];
                        }
                    }
                }
                temperatureAmplitude = Math.Round(maximumTemperature - minimumTemperature);
            }
            return temperatureAmplitude;
        }

        public static void PrintArrayTemperatureAmplitude(WeatherObjectsCollection weatherArray)
        {
            double temperatureAmplitude = CountArrayTemperatureAmplitude(weatherArray);
            if (temperatureAmplitude < 0)
            {
                Console.WriteLine("Коллекция пустая, поэтому амплитуду температур определить невозможно.");
            }
            else
            {
                Console.WriteLine($"Амплитуда температур в коллекции составляет {temperatureAmplitude}.");
            }
        }

        static void Main()
        {
            // Part 1
            Weather weatherMonday = new Weather(); // создание экземпляра с помощью конструктора без параметров
            OutputData.PrintObjectProperties(weatherMonday); // вывод атрибутов экземпляра

            Weather weatherTuesday = new Weather(30, 5, 800); // создание экземпляра с помощью конструктора, задающего все 3 свойства
            OutputData.PrintObjectProperties(weatherTuesday); // вывод атрибутов экземпляра

            Weather weatherWednesday = new Weather(weatherTuesday); // создание экземпляра с помощью конструктора, переносящего значения из другого экземпляра
            OutputData.PrintObjectProperties(weatherWednesday); // вывод атрибутов экземпляра
            OutputData.PrintDewPointValueStaticWay(weatherWednesday); // для значений экземпляра выводится точка росы, применяется статический метод

            Weather weatherThursday = new Weather(25); // создание экземпляра с помощью конструктора, задающего только 1 свойство - температуру
            OutputData.PrintObjectProperties(weatherThursday); // вывод атрибутов экземпляра
            OutputData.PrintDewPointValueClassMethodWay(weatherThursday); // для значений экземпляра выводится точка росы, применяется метод класса

            OutputData.PrintObjectsQuantity(); // вывод числа созданных объектов

            Console.WriteLine();

            //Part 2
            Weather weatherDay1 = new Weather(4, 88, 760);
            OutputData.GetOppositeWeather(weatherDay1); // применение операции нахождения отрицательного значения (-<object>)
            Console.WriteLine();

            OutputData.CountIfHumidityIsHigher80(weatherDay1); // применение операции инверсии (!<object>)
            OutputData.CountIfHumidityIsHigher80(weatherThursday); // применение операции инверсии (!<object>)
            Console.WriteLine();

            OutputData.PrintHumIndex(weatherDay1); // применение неявной операции приведения типов
            Console.WriteLine();

            OutputData.CountIfPressureIsHigher760(weatherDay1); // применение явной операции приведения типов
            OutputData.CountIfPressureIsHigher760(weatherTuesday); // применение явной операции приведения типов
            Console.WriteLine();

            OutputData.PrintObjectProperties(weatherThursday - 5); // применение операции вычитания числа из экземпляра класса Weather
            Console.WriteLine();

            OutputData.PrintObjectProperties(weatherThursday * 1.5); // применение операции умножения экземпляра класса Weather на число
            Console.WriteLine();

            OutputData.PrintIfObjectsAreEqual(weatherWednesday, weatherTuesday); // применение метода Equals
            OutputData.PrintIfObjectsAreEqual(weatherDay1, 5); // применение метода Equals
            Console.WriteLine();

            //Part 3
            WeatherObjectsCollection weatherArray = new(); // создание новой коллекции, состоящей по умолчанию из 10 экземпляров класса Weather
            OutputData.PrintWeatherArrayElements(weatherArray); // вывод объектов коллекции
            Console.WriteLine();

            WeatherObjectsCollection weatherArray1 = new(5); // создание новой коллекции, содержащей 5 объектов, заполненных случайными числами
            OutputData.PrintWeatherArrayElements(weatherArray1); // вывод объектов коллекции
            Console.WriteLine();
            
            WeatherObjectsCollection weatherArray2 = OutputData.CreateWeatherCollection(5); // создание новой коллекции, содержащей 5 объектов, заполненных вручную
            OutputData.PrintWeatherArrayElements(weatherArray2); // вывод объектов коллекции
            Console.WriteLine();

            WeatherObjectsCollection weatherArray3 = new(weatherArray1); // создание новой коллекции, являющейся копией другой коллекции
            OutputData.PrintWeatherArrayElements(weatherArray3); // вывод созданной коллекции
            Console.WriteLine();

            try
            {
                weatherArray1[0] = new Weather(30, 6, 800); // запись объекта с существующим индексом
                OutputData.PrintWeatherArrayElements(weatherArray1); // при изменении значений одного из объектов копируемой коллекции
                OutputData.PrintWeatherArrayElements(weatherArray3); // значения в коллекции-копии не меняются

                OutputData.PrintObjectProperties(weatherArray1[1]); // получение объекта с существующим индексом
                OutputData.PrintObjectProperties(weatherArray1[5]); // получение объекта с несуществующим индексом
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine();

            try
            {
                weatherArray1[-1] = new Weather(); // запись объекта с несуществующим индексом
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine();

            PrintArrayTemperatureAmplitude(weatherArray1);
            Console.WriteLine();

            OutputData.PrintObjectsQuantity();
            OutputData.PrintCollectionsQuantity();
        }
    }
}
