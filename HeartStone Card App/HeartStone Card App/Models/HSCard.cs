using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HeartStone_Card_App
{
    class HSCard
    {


        public HSCard()
        {
            FetchApi();
        }

        public async void FetchApi()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards"),
                Headers =
                {
                    { "x-rapidapi-key", "b2594b1a5fmsh1d3977bc30a580ap11e4c0jsnb371aab02166" },
                    { "x-rapidapi-host", "omgvamp-hearthstone-v1.p.rapidapi.com" },
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(body);
            }
        }
    }
}
