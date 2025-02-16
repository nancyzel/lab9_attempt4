namespace lab9
{
    public class Weather
    {
        /// <summary>
        /// температура воздуха в градусах Цельсия
        /// </summary>
        private double temperature;

        /// <summary>
        /// влажность воздуха в %
        /// </summary>
        private int humidity;

        /// <summary>
        /// атмосферное давление в мм рт. ст.
        /// </summary>
        private int pressure;

        /// <summary>
        /// количество созданных объектов
        /// </summary>
        private static int objectsQuantity = 0;

        /// <summary>
        /// обработка значения для поля temperature
        /// </summary>
        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
            }
        }

        /// <summary>
        /// обработка значения для поля humidity
        /// </summary>
        public int Humidity
        {
            get => humidity;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Влажность не может быть меньше 0%");
                }
                else
                {
                    if (value > 100)
                    {
                        throw new Exception("Влажность не может превышать 100%");
                    }
                    else
                    {
                        humidity = value;
                    }
                }
            }
        }

        /// <summary>
        /// обработка значения для поля pressure
        /// </summary>
        public int Pressure
        {
            get => pressure;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Атмосферное давление не может быть меньше 0");
                }
                else
                {
                    pressure = value;
                }
            }
        }

        /// <summary>
        /// создание объекта через задание всех атрибутов
        /// </summary>
        /// <param name="currentTemperature">введенная пользователем температура</param>
        /// <param name="currentHumidity">введенная пользователем влажность</param>
        /// <param name="currentPressure">введенное пользователем давление</param>
        public Weather(double currentTemperature, int currentHumidity, int currentPressure)
        {
            this.Temperature = currentTemperature;
            this.Humidity = currentHumidity;
            this.Pressure = currentPressure;
            objectsQuantity++;
        }

        /// <summary>
        /// создание объекта через задание температуры
        /// </summary>
        /// <param name="currentTemperature">введенная пользователем температура</param>
        public Weather(double currentTemperature)
        {
            Temperature = currentTemperature;
            Humidity = 40;
            Pressure = 700;
            objectsQuantity++;
        }

        /// <summary>
        /// создание объекта через указание другого объекта
        /// </summary>
        /// <param name="currentWeather">объект класса Weather</param>
        public Weather(Weather currentWeather)
        {
            this.Temperature = currentWeather.Temperature;
            this.Humidity = currentWeather.Humidity;
            this.Pressure = currentWeather.Pressure;
            objectsQuantity++;
        }

        /// <summary>
        /// создание объекта с атрибутами по умолчанию
        /// </summary>
        public Weather() : this(15.5, 50, 760)
        { }

        /// <summary>
        /// вывод атрибутов объекта
        /// </summary>
        public void ShowWeatherConditions(out double currentTemperature, out int currentHumidity, out int currentPressure)
        {
            currentTemperature = Temperature;
            currentHumidity = Humidity;
            currentPressure = Pressure;
        }

        /// <summary>
        /// вывод значения точки росы - метод класса
        /// </summary>
        /// <param name="studiedTemperature">Температура</param>
        /// <param name="studiedHumidity">Влажность</param>
        /// <returns>значение точки росы</returns>
        public double GetDewPointClassMethod(out double studiedTemperature, out int studiedHumidity)
        {
            const double a = 17.27;
            const double b = 237.7;
            studiedTemperature = Temperature;
            studiedHumidity = Humidity;
            double dewPointCoefficient = (a * studiedTemperature) / (b + studiedTemperature) + Math.Log(((double)studiedHumidity / 100));
            double dewPoint = (b * dewPointCoefficient) / (a - dewPointCoefficient);
            return Math.Round(dewPoint, 4);
        }

        /// <summary>
        /// вывод значения точки росы - метод класса
        /// </summary>
        /// <param name="currentWeather">объект класса Weather с набором характеристик: температура, влажность, давление</param>
        /// <param name="studiedTemperature">Температура</param>
        /// <param name="studiedHumidity">Влажность</param>
        /// <returns>значение точки росы</returns>
        public static double GetDewPointStaticMethod(Weather currentWeather, out double studiedTemperature, out int studiedHumidity)
        {
            const double a = 17.27;
            const double b = 237.7;
            studiedTemperature = currentWeather.Temperature;
            studiedHumidity = currentWeather.Humidity;
            double dewPointCoefficient = (a * studiedTemperature) / (b + studiedTemperature) + Math.Log(((double)studiedHumidity / 100));
            double dewPoint = (b * dewPointCoefficient) / (a - dewPointCoefficient);
            return Math.Round(dewPoint, 4);
        }

        /// <summary>
        /// вывод числа созданных экземпляров класса
        /// </summary>
        public static int GetObjectsQuantity()
        {
            return objectsQuantity;
        }

        /// <summary>
        /// Оператор нахождения противоположного по значению элемента
        /// </summary>
        /// <param name="currentWeather">Исходный объект класса Weather с набором характеристик: температура, влажность, давление</param>
        /// <returns>объект класса Weather с набором характеристик: температура, влажность, давление</returns>
        public static Weather operator -(Weather currentWeather)
        {
            Weather updatedWeather = new Weather();
            updatedWeather.Temperature = -currentWeather.Temperature;
            updatedWeather.Humidity = currentWeather.Humidity;
            updatedWeather.Pressure = currentWeather.Pressure;
            return updatedWeather;
        }

        public static bool operator !(Weather currentWeather)
        {
            bool isHumidityHigh = false;
            if (currentWeather.Humidity > 80)
            {
                isHumidityHigh = true;
            }
            return isHumidityHigh;
        }

        public static implicit operator double(Weather currentWeather)
        {
            double studiedTemperature = currentWeather.Temperature * 9 / 5 + 32;
            int studiedHumidity = currentWeather.Humidity;
            double humIndexValue = -42.379 + (2.04901523 * studiedTemperature) + (10.14333127 * studiedHumidity)
                - (0.22475541 * studiedTemperature * studiedHumidity)
                - (0.00683783 * Math.Pow(studiedTemperature, 2)) - (0.05481717 * Math.Pow(studiedHumidity, 2))
                + (0.00122874 * Math.Pow(studiedTemperature, 2) * studiedHumidity)
                + (0.00085282 * studiedTemperature * Math.Pow(studiedHumidity, 2))
                - (0.00000199 * Math.Pow(studiedTemperature, 2) * Math.Pow(studiedHumidity, 2));
            return Math.Round(humIndexValue, 2);
        }

        public static explicit operator bool(Weather currentWeather)
        {
            bool isPressureHigh = false;
            if (currentWeather.Pressure > 760)
            {
                isPressureHigh = true;
            }
            return isPressureHigh;
        }

        public static Weather operator -(Weather currentWeather, double temperatureDelta)
        {
            Weather updatedWeather = new Weather();
            updatedWeather.Temperature = Math.Round(currentWeather.Temperature - temperatureDelta, 4);
            updatedWeather.Humidity = currentWeather.Humidity;
            updatedWeather.Pressure = currentWeather.Pressure;
            return updatedWeather;
        }

        public static Weather operator *(Weather currentWeather, double parametersChangePercent)
        {
            Weather updatedWeather = new Weather();
            updatedWeather.Temperature = Math.Round(currentWeather.Temperature * (1 + parametersChangePercent/(double)100), 4);
            updatedWeather.Humidity = (int)(currentWeather.Humidity * (1 + parametersChangePercent / (double)100));
            updatedWeather.Pressure = (int)(currentWeather.Pressure * (1 + parametersChangePercent / (double)100));
            return updatedWeather;
        }

        public static bool operator <(Weather currentWeather1, Weather currentWeather2)
        {
            return currentWeather1.Temperature < currentWeather2.Temperature;
        }

        public static bool operator >(Weather currentWeather1, Weather currentWeather2)
        {
            return currentWeather1.Temperature > currentWeather2.Temperature;
        }

        public static double operator -(Weather currentWeather1, Weather currentWeather2)
        {
            return currentWeather1.Temperature - currentWeather2.Temperature;
        }

        public override bool Equals(object? checkedObject)
        {
            if (checkedObject is Weather checkedWeather)
            {
                return checkedWeather.Temperature == this.Temperature && checkedWeather.Humidity == this.Humidity && checkedWeather.Pressure == this.Pressure;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
