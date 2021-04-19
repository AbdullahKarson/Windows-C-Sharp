using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static HeartStoneCardClass.Rootobject;

namespace HeartStoneCardClass
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();

            //Debug.WriteLine("Finished Card Fetch");
        }

        static async Task RunAsync()
        {
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(
                string.Format("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/sets/classic")
                );

            webReq.Method = "GET";
            webReq.Headers["x-rapidapi-key"] = "b2594b1a5fmsh1d3977bc30a580ap11e4c0jsnb371aab02166";
            webReq.Headers["x-rapidapi-host"] = "omgvamp-hearthstone-v1.p.rapidapi.com";

            HttpWebResponse WebResp = (HttpWebResponse)webReq.GetResponse();

            Debug.WriteLine(WebResp.StatusCode);
            Debug.WriteLine(WebResp.Server);

            string jsonString;
            using(Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Debug.WriteLine(jsonString);

            var bundle = JsonConvert.DeserializeObject<Rootobject>(jsonString);
        }
    }
}
