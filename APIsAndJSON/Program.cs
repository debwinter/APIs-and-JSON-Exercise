using Newtonsoft.Json;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WEATHER API\n------------------");
            Console.WriteLine();
            new OpenWeatherMapAPI();

            Console.WriteLine();
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("RON VS KANYE API\n------------------");
            Console.WriteLine();
            new RonVSKanyeAPI();
        }
    }
}
