using System;
using System.Collections;

namespace Ex7ForClass
{
    public interface IObserver
    {
        public void update(float temp, float humi, float pres);
    }

	public interface IDisplayElement
    {
		public void display();
    }

    interface ISubject
    {
        public void registerObserver(IObserver o);
        public void removeObserver(IObserver o);
        public void notifyObservers();
    }

    class CurrentDataDisplay : IObserver, IDisplayElement
	{
		private float temp;
		private float humi;
		private float pres;
		private WeatherData weatherData;

		public CurrentDataDisplay(WeatherData weatherData)
        {
			this.weatherData = weatherData;
			weatherData.registerObserver(this);
        }

		public void update(float temp, float humi, float pres)
		{
			this.temp = temp;
			this.humi = humi;
			this.pres = pres;
			this.display();
		}

		public void display()
        {
			Console.WriteLine($"현재 날씨 정보 ( 온도 : {this.temp}, 습도 : {this.humi}, 기압 : {this.pres} )");
        }
    }

	class PastDataDisplay : IObserver, IDisplayElement
	{
		private float temp;
		private float humi;
		private float pres;
		private WeatherData weatherData;

		public PastDataDisplay(WeatherData weatherData)
		{
			this.weatherData = weatherData;
			weatherData.registerObserver(this);
		}

		public void update(float temp, float humi, float pres)
		{
			this.temp = temp;
			this.humi = humi;
			this.pres = pres;
			this.display();
		}

		public void display()
		{
			Console.WriteLine($"과거 날씨 정보 ( 온도 : {this.temp}, 습도 : {this.humi}, 기압 : {this.pres} )");
		}
	}

	class WeatherData : ISubject
    {
        private ArrayList observers;
        private float temp;
        private float humi;
        private float pres;

        public WeatherData()
        {
            observers = new ArrayList();
        }

		public void registerObserver(IObserver o)
		{
			observers.Add(o);
		}

		public void removeObserver(IObserver o)
		{
			observers.Remove(o);
		}

		public void notifyObservers()
		{
			foreach (IObserver observer in observers)
			{
				observer.update(temp, humi, pres);
			}
		}

		public void measurementsChanged()
		{
			notifyObservers();
		}

		public void setMeasurements(float temp, float humi, float pres)
		{
			this.temp = temp;
			this.humi = humi;
			this.pres = pres;
			measurementsChanged();
		}

		public float getTemp()
		{
			return temp;
		}

		public float getHumi()
		{
			return humi;
		}

		public float getPres()
		{
			return pres;
		}
	}

    class MainApp
    {
        static void Main(string[] args)
        {
			WeatherData weatherData = new WeatherData();
			CurrentDataDisplay currentDisplay = new CurrentDataDisplay(weatherData);
			PastDataDisplay pastDisplay = new PastDataDisplay(weatherData);

			weatherData.setMeasurements(30, 65, 20);
		}
    }
}
