using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KrakenStartup.ThirdParty.HereMap
{
    /// <summary>
    /// Provides services for interacting with the HERE Maps API.
    /// </summary>
    public static class HereMapService
    {
        // TODO: Move the API Key to a secure configuration file (e.g., appsettings.json) instead of hardcoding it.
        private static readonly string HereApiKey = "XXXXXXXX";

        /// <summary>
        /// Calculates the distance and travel time from multiple origin points to a single destination using the HERE Maps Routing API.
        /// </summary>
        /// <param name="latitude">The latitude of the destination.</param>
        /// <param name="longitude">The longitude of the destination.</param>
        /// <param name="originAddressList">A list of origin addresses with their latitude and longitude.</param>
        /// <returns>A list of matrix entries containing distance and travel time information.</returns>
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
                                  $"apiKey={HereApiKey}" +
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

    /// <summary>
    /// Represents a geographical location with latitude and longitude coordinates.
    /// </summary>
    public class HereAddressLocalization
    {
        /// <summary>
        /// Gets or sets the latitude of the location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location.
        /// </summary>
        public double Longitude { get; set; }
    }
}
