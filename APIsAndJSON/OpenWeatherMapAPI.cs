using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        static OpenWeatherMapAPI()
        {
            HttpClient client = new HttpClient();

            Console.WriteLine("Enter a city name:");
            string cityName = Console.ReadLine();

            string weatherUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid=33538767ea12c649a7d0bf1b82b4206a";

            var weatherObj = JArray.Parse(client.GetStringAsync(weatherUrl).Result);
            while (!weatherObj.HasValues)
            {
                Console.WriteLine("I'm sorry, I don't know any cities by that name.");
                Console.Write("Please try another city name: ");
                cityName = Console.ReadLine();
                weatherUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid=33538767ea12c649a7d0bf1b82b4206a";
                weatherObj = JArray.Parse(client.GetStringAsync(weatherUrl).Result);
            }

            Console.WriteLine();
            Console.WriteLine("Which did you mean?");
            var validInputs = new List<string>();
            for (int i = 0; i < weatherObj.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {weatherObj[i]["name"]}, {weatherObj[i]["state"]}, {weatherObj[i]["country"]}");
                validInputs.Add((i + 1).ToString());
            }
            Console.WriteLine();
            Console.Write("Enter the corresponding number: ");
            string userInput = Console.ReadLine();
            while (!validInputs.Contains(userInput)) {
                Console.Write("Invalid entry. Please try again: ");
                userInput = Console.ReadLine();
            }
            int selectedIndex = int.Parse(userInput) - 1;
            Console.WriteLine();
            weatherUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={weatherObj[selectedIndex]["lat"]}&lon={weatherObj[selectedIndex]["lon"]}&appid=33538767ea12c649a7d0bf1b82b4206a";

            var weather = JObject.Parse(client.GetStringAsync(weatherUrl).Result);
            var currentTemp = Math.Round(double.Parse(weather["current"]["temp"].ToString()), 2) - 273.15;
            var currentTempInFahrenheit = currentTemp * 1.8 + 32;
            Console.Write("Current temp: ");
            if (weatherObj[selectedIndex]["country"].ToString() == "US") Console.WriteLine($"{currentTempInFahrenheit}*F");
            else Console.WriteLine($"{currentTemp}*C");
        }
        
    }
}
