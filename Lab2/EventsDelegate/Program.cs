using System;

namespace EventsDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Temperature tempConverter = FahrenheitToCelsius;
            tempConverter.Invoke(12);
            double tempInFahrenheit = 96;
            double tempInCelsius = tempConverter(tempInFahrenheit);

            Console.WriteLine($"Temperature in Fahrenheit: {tempInFahrenheit}°F");
            Console.WriteLine($"Temperature in Celsius: {tempInCelsius}°C");
        }
        public delegate double Temperature(double temp);
        public static double FahrenheitToCelsius(double temp)
        {
            return (temp - 32) * 5 / 9;
        }

    }
}