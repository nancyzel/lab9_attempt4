namespace lab9
{
    public class WeatherObjectsCollection
    {
        /// <summary>
        /// для генерации случайных чисел в объектах Weather
        /// </summary>
        Random randomNumber = new Random();

        /// <summary>
        /// коллекция объектов Weather
        /// </summary>
        private Weather[] weatherObjectsArray;

        /// <summary>
        /// число созданных коллекций
        /// </summary>
        static int collectionsQuantity = 0;

        /// <summary>
        /// длина коллекции объектов Weather
        /// </summary>
        private int arrayLength;

        /// <summary>
        /// длина коллекции объектов Weather
        /// </summary>
        public int Length
        {
            get => weatherObjectsArray.Length;
        }

        /// <summary>
        /// конструктор коллекции объектов Weather без параметров
        /// </summary>
        public WeatherObjectsCollection()
        {
            weatherObjectsArray = new Weather[100];
            for (int i = 0; i < 100; i++)
            {
                weatherObjectsArray[i] = new Weather();
            }
            collectionsQuantity++;
        }

        /// <summary>
        /// конструктор коллекции объектов Weather, заполняемой случайными числами, по заданной длине
        /// </summary>
        /// <param name="arrayLength">длина массива</param>
        public WeatherObjectsCollection(int arrayLength)
        {
            weatherObjectsArray = new Weather[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                weatherObjectsArray[i] = new Weather(randomNumber.Next(-27300, 100000) / (double)100, randomNumber.Next(0, 100), randomNumber.Next(700, 900));
            }
            collectionsQuantity++;
        }

        public WeatherObjectsCollection(int arrayLength, Tuple<double, int, int>[] weatherCollection)
        {
            weatherObjectsArray = new Weather[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                (double currentTemperature, int currentHumidity, int currentPressure) = weatherCollection[i];
                weatherObjectsArray[i] = new Weather(currentTemperature, currentHumidity, currentPressure);
            }
            collectionsQuantity++;
        }

        /// <summary>
        /// создание копии коллекции объектов Weather с использованием глубокого копирования
        /// </summary>
        /// <param name="anotherWeatherObjectsArray">другая коллекция объектов Weather, копия которого создается в методе</param>
        public WeatherObjectsCollection(WeatherObjectsCollection anotherWeatherObjectsArray)
        {
            weatherObjectsArray = new Weather[anotherWeatherObjectsArray.Length];
            for (int i = 0; i < Length; i++)
            {
                weatherObjectsArray[i] = new Weather(anotherWeatherObjectsArray[i]);
            }
            collectionsQuantity++;
        }

        /// <summary>
        /// вывод объектов коллекции в консоль
        /// </summary>
        public Tuple<double, int, int>[] GetCollectionElements()
        {
            Tuple<double, int, int>[] weatherCollection = new Tuple<double, int, int>[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                weatherCollection[i] = Tuple.Create(weatherObjectsArray[i].Temperature, weatherObjectsArray[i].Humidity, weatherObjectsArray[i].Pressure);
            }
            return weatherCollection;
        }

        /// <summary>
        /// индексатор для коллекции объектов Weather
        /// </summary>
        /// <param name="index">порядковый номер объекта Weather в коллекции</param>
        /// <returns>элемент (объект) коллекции с заданным индексом</returns>
        /// <exception cref="IndexOutOfRangeException">искомый порядковый номер отсутствует в коллекции</exception>
        public Weather this[int index]
        {
            get
            {
                if (index >= 0 && index < weatherObjectsArray.Length)
                {
                    return weatherObjectsArray[index];
                }
                else
                    throw new IndexOutOfRangeException("Искомый индекс находится за пределами коллекции");
            }
            set
            {
                if (index >= 0 && index < weatherObjectsArray.Length)
                {
                    weatherObjectsArray[index] = value;
                }
                else
                    throw new IndexOutOfRangeException("Искомый индекс находится за пределами коллекции");
            }
        }

        /// <summary>
        /// вывод числа созданных экземпляров класса
        /// </summary>
        public static int GetCollectionsQuantity()
        {
            return collectionsQuantity;
        }
    }
}
