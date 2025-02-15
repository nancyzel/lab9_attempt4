namespace lab9
{
    internal static class OutputData
    {
        static bool CheckDiapasonBelonging(int number, int startNumber, int endNumber) => (startNumber <= number && number <= endNumber);

        static bool CheckDiapasonBelonging(double number, double startNumber, double endNumber) => (startNumber <= number && number <= endNumber);

        /// <summary>
        /// Считывание введенного пользователем значения, проверка корректности ввода числа типа Int32
        /// </summary>
        /// <param name="inputValue">Возвращаемое значение - целое число</param>
        static void ReadInput(string message, ref int inputValue)
        {
            bool isAppropriateNumber = false;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    inputValue = int.Parse(Console.ReadLine());
                    isAppropriateNumber = true;
                }
                catch (FormatException)
                {
                    isAppropriateNumber = false;
                    Console.WriteLine($"Введенное значение не является целым числом.");
                }
                catch (OverflowException)
                {
                    isAppropriateNumber = false;
                    Console.WriteLine($"Вы ввели слишком большое по модулю целое число.");
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Ошибка при выделении памяти.");
                }
            } while (!isAppropriateNumber);
        }

        /// <summary>
        /// Считывание введенного пользователем значения, проверка корректности ввода числа типа Double
        /// </summary>
        /// <param name="message">сообщение для пользователя перед вводом</param>
        /// <param name="inputValue">вводимое значение</param>
        static void ReadInput(string message, ref double inputValue)
        {
            bool isAppropriateNumber = false;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    inputValue = double.Parse(Console.ReadLine());
                    isAppropriateNumber = true;
                }
                catch (FormatException)
                {
                    isAppropriateNumber = false;
                    Console.WriteLine($"Введенное значение не является вещественным числом.");
                }
                catch (OverflowException)
                {
                    isAppropriateNumber = false;
                    Console.WriteLine($"Вы ввели слишком большое число.");
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Ошибка при выделении памяти.");
                }
            } while (!isAppropriateNumber);
        }

        /// <summary>
        /// Проверка считанного числа от ввода пользователя на принадлежность диапазону
        /// </summary>
        /// <param name="startPoint">Нижняя граница допустимого диапазона (включительно)</param>
        /// <param name="endPoint">Верхняя граница допустимого диапазона (включительно)</param>
        static int CheckReadIntegerNumber(string message, int startPoint, int endPoint)
        {
            int number = 0;
            do
            {
                ReadInput(message, ref number);
                if (!CheckDiapasonBelonging(number, startPoint, endPoint))
                {
                    Console.WriteLine($"Введенное вами число не входит в диапазон от {startPoint} до {endPoint}.");
                }
            } while (number < startPoint || number > endPoint);
            return number;
        }

        static double CheckReadDoubleNumber(string message, double startPoint, double endPoint)
        {
            double number = 0;
            do
            {
                ReadInput(message, ref number);
                if (!CheckDiapasonBelonging(number, startPoint, endPoint))
                {
                    Console.WriteLine($"Введенное вами число не входит в диапазон от {startPoint} до {endPoint}.");
                }
            } while (number < startPoint || number > endPoint);
            return number;
        }

        /// <summary>
        /// вывод свойств объекта Weather (температура, влажность, давление)
        /// </summary>
        /// <param name="currentWeather">объект класса Weather с набором характеристик: температура, влажность, давление</param>
        public static void PrintObjectProperties(Weather currentWeather)
        {
            currentWeather.ShowWeatherConditions(out double currentTemperature, out int currentHumidity, out int currentPressure);
            Console.WriteLine($"Температура воздуха {currentTemperature}°C; влажность {currentHumidity}%; давление {currentPressure} мм рт. ст.");
        }

        /// <summary>
        /// Вывод значения точки росы (демонстрация работы метода класса)
        /// </summary>
        /// <param name="currentWeather">объект класса Weather с набором характеристик: температура, влажность, давление</param>
        public static void PrintDewPointValueClassMethodWay(Weather currentWeather)
        {
            double dewPoint = currentWeather.GetDewPointClassMethod(out double temperature, out int humidity);
            Console.WriteLine($"Точка росы при температуре {temperature}°C и влажности {humidity}% составляет {dewPoint}.");
        }

        /// <summary>
        /// Вывод значения точки росы (демонстрация работы статического метода)
        /// </summary>
        /// <param name="currentWeather">объект класса Weather с набором характеристик: температура, влажность, давление</param>
        public static void PrintDewPointValueStaticWay(Weather currentWeather)
        {
            double dewPoint = Weather.GetDewPointStaticMethod(currentWeather, out double temperature, out int humidity);
            Console.WriteLine($"Точка росы при температуре {temperature}°C и влажности {humidity}% составляет {dewPoint}.");
        }

        public static void GetOppositeWeather(Weather currentWeather)
        {
            PrintObjectProperties(-currentWeather);
        }

        public static void CountIfHumidityIsHigher80(Weather currentWeather)
        {
            bool ifHumidityIsHigher80 = !currentWeather;
            if (ifHumidityIsHigher80)
            {
                Console.WriteLine("Влажность воздуха выше 80%.");
            }
            else
            {
                Console.WriteLine("Влажность воздуха ниже 80%.");
            }
        }

        public static void PrintHumIndex(Weather currentWeather)
        {
            double humIndex = currentWeather;
            currentWeather.ShowWeatherConditions(out double currentTemperature, out int currentHumidity, out int currentPressure);
            Console.WriteLine($"При температуре {currentTemperature}°C, влажности {currentHumidity}%, значение humindex составляет {humIndex}.");
        }

        public static void CountIfPressureIsHigher760(Weather currentWeather)
        {
            bool IfPressureIsHigher760 = (bool)currentWeather;
            if (IfPressureIsHigher760)
            {
                Console.WriteLine("Атмосферное давление выше 760 мм рт. ст.");
            }
            else
            {
                Console.WriteLine("Атмосферное давление 760 мм рт. ст. или ниже.");
            }
        }

        public static void PrintIfObjectsAreEqual(Weather currentWeather, object comparedObject)
        {
            bool areObjectsEqual = currentWeather.Equals(comparedObject);
            if (areObjectsEqual)
            {
                Console.WriteLine("Объекты принадлежат классу Weather и обладают одинаковыми свойствами.");
            }
            else
            {
                Console.WriteLine("Хотя бы один объект не принадлежат классу Weather или объекты обладают разными свойствами.");
            }
        }

        public static void PrintObjectsQuantity()
        {
            int objectsQuantity = Weather.GetObjectsQuantity();
            Console.WriteLine($"Количество экземпляров класса Weather, созданных в программе на данный момент, равно {objectsQuantity}.");
        }

        public static void PrintCollectionsQuantity()
        {
            int collectionsQuantity = WeatherObjectsCollection.GetCollectionsQuantity();
            Console.WriteLine($"Количество коллекций экземпляров класса Weather, созданных в программе на данный момент, равно {collectionsQuantity}.");
        }

        public static void PrintWeatherArrayElements(WeatherObjectsCollection weatherArray)
        {
            Tuple<double, int, int>[] weatherCollection = weatherArray.GetCollectionElements();
            Console.WriteLine("Состав массива объектов Weather:");
            for (int i = 0; i < weatherCollection.Length; i++)
            {
                (double currentTemperature, int currentHumidity, int currentPressure) = weatherCollection[i];
                Console.WriteLine($"Температура воздуха {currentTemperature}°C; влажность {currentHumidity}%; давление {currentPressure} мм рт. ст.");
            }
        }

        public static WeatherObjectsCollection CreateWeatherCollection(int collectionLength)
        {
            Tuple<double, int, int>[] inputWeatherArray = new Tuple<double, int, int>[collectionLength];
            for (int i = 0; i < inputWeatherArray.Length; i++)
            {
                double currentTemperature = CheckReadDoubleNumber($"Введите температуру в градусах Цельсия для объекта с номером {i + 1}:", -273.15, 1000000);
                int currentHumidity = CheckReadIntegerNumber($"Введите влажность воздуха в процентах для объекта с номером {i+1}:", 0, 100);
                int currentPressure = CheckReadIntegerNumber($"Введите атмосферное давление в мм рт. ст. для объекта с номером {i+1}:", 700, 900);
                inputWeatherArray[i] = Tuple.Create(currentTemperature, currentHumidity, currentPressure);
            }
            WeatherObjectsCollection weatherArray = new(collectionLength, inputWeatherArray);
            return weatherArray;
        }
    }
}
