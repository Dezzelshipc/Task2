namespace Task2
{
    interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }

    class WeatherData : Subject
    {
        private List<Observer> observers = new List<Observer>();
        
        public void registerObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            observers.Remove(observer);
        }
        public void notifyObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(getTemperature(), getHumidity(), getPressure());
            }
        }

        public float getTemperature()
        {
            return 0;
        }

        public float getHumidity()
        {
            return 0;
        }

        public float getPressure()
        {
            return 0;
        }

        public void measurementsChanged()
        {
            notifyObservers();
        }
    
    }

    interface Observer
    {
        void update(float temperature, float humidity, float pressure);
        void display();
    }

    class CurrentConditionsDisplay : Observer
    {
        float temperature;
        float humidity;
        float pressure;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature + " C");
            Console.WriteLine("Humidity: " + humidity + " %");
            Console.WriteLine("Pressure: " + pressure);
        }
    }

    class StatisticsDisplay : Observer
    {
        float temperature;
        float humidity;
        float pressure;

        public StatisticsDisplay(WeatherData weatherData)
        {
            weatherData.registerObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.display();
        }

        public void display()
        {
            Console.WriteLine("Temperature last week: " + (temperature-10) + " C");
            Console.WriteLine("Humidity last week: " + (humidity+12)*2+" %");
            Console.WriteLine("Pressure last week: " + (pressure+10));
        }
    }

    class ForecastDisplay : Observer
    {
        float temperature;
        float humidity;
        float pressure;

        public ForecastDisplay(WeatherData weatherData)
        {
            weatherData.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.display();
        }
        public void display()
        {
            Console.WriteLine("Expected Temperature: " + (temperature + 10) + " C");
            Console.WriteLine("Expected Humidity: " + (humidity + 20) + " %");
            Console.WriteLine("Expected Pressure: " + (pressure + 1));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            var statisticsDisplay = new StatisticsDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);

            weatherData.measurementsChanged();
        }
    }
}