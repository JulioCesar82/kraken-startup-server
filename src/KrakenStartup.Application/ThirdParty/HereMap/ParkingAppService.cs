using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KrakenStartup.ThirdParty.HereMap
{
    public static class HereMapService
    {
        private static readonly string hereApiKey = "Gwecv9sAyqQimIdyQoM7AM8kGU21hk02I_hA5-_KKnU";

        public static async Task<List<MatrixEntry>> GetDistanceByHereApi(double latitude, double longitude, List<HereAddressLocalization> originAddressList)
        {
            var originCoordinates = "";

            for (int i = 0; i < originAddressList.Count; i++)
            {
                originCoordinates += $"&start{i}={originAddressList[i].Latitude},{originAddressList[i].Longitude}";
            }

            using (var client = new HttpClient())
            {
                var url = new Uri("https://matrix.route.ls.hereapi.com/routing/7.2/calculatematrix.json?" +
                                  $"apiKey={hereApiKey}" +
                                  "&mode=fastest;pedestrian" +
                                  "&summaryAttributes=traveltime,distance" +
                                  $"&destination0={latitude},{longitude}" +
                                  $"{originCoordinates}");

                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                var routingResponse = JsonConvert.DeserializeObject<HereRoutingResponse>(json);

                return routingResponse.Response.MatrixEntry;
            }
        }
    }

    public class HereAddressLocalization
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
