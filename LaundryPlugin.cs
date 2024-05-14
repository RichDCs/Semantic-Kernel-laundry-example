// AvailableFunctions class

using System;

namespace AutoFunctionCalling
{
    // different weather enum
    public enum Weather
    {
        Rainy,
        Cloudy,
        Sunny,
        Snowing
    }

    public static class LaundryPlugin
    {
        public static bool laundryHung = false;

        public static DateTime GetUtcTime()
        {
        // generate a random time of the day
            Random random = new();
            int hour = random.Next(0, 24);
            int minute = random.Next(0, 60);
            int second = random.Next(0, 60);
            var date = new DateTime(2024, 5, 16, hour, minute, second);
            Console.WriteLine($"Current time: {date}");
            return date;
        }

        // hang the laundry outside
        public static void HangLaundry()
        {
            Console.WriteLine("Hanging the laundry outside :)");
            laundryHung = true;
        }

        public static string GetCurrentWeather()
        {
            // return a random weather
            Random random = new();
            var currentWeather = (Weather)random.Next(0, 4);
            Console.WriteLine($"Current weather: {currentWeather}");
            return currentWeather.ToString();
        }

        public static async Task WaitSomeTime()
        {
            // simulate a delay
            Console.WriteLine("Waiting some time...");
            await Task.Delay(2000);
        }
    }
}