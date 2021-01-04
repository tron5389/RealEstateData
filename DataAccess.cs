using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstateData
{
    public class DataAccess
    {
        public DataAccess()
        {
            client = new HttpClient();
        }

        public HttpClient client { get; private set; }

        async public Task<string> GetRentData()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://realtor.p.rapidapi.com/properties/list-for-rent?state_code=GA&limit=200&city=Atlanta&offset=0&postal_code=30312&beds_min=2&sort=relevance&baths_min=1"),
                Headers =
                {
                    { "x-rapidapi-key", "1444b95a90msheb89124c8a7ae14p135fafjsna4f5d0eff8c0" },
                    { "x-rapidapi-host", "realtor.p.rapidapi.com" },
                },
            };
            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "data retrieval failed";
            }
        }
    }
}