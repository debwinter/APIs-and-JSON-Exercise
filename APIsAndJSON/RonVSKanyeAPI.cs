using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        static RonVSKanyeAPI()
        {
            HttpClient client = new HttpClient();

            string ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string kanyeUrl = "https://api.kanye.rest/";

            var ronQuote = JArray.Parse(client.GetStringAsync(ronUrl).Result);
            var kanyeQuote = JObject.Parse(client.GetStringAsync(kanyeUrl).Result);

            for (int quoteCounter = 0; quoteCounter < 5; quoteCounter++)
            {
                Console.WriteLine($"KANYE:\n{kanyeQuote["quote"]}\n");
                Thread.Sleep(500);
                Console.WriteLine($"RON:\n{ronQuote[0]}\n");
                Thread.Sleep(1000);
                kanyeQuote = JObject.Parse(client.GetStringAsync(kanyeUrl).Result);
                ronQuote = JArray.Parse(client.GetStringAsync(ronUrl).Result);
            }
            
        }
    }
}
