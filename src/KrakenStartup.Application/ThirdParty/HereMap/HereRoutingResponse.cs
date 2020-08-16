using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KrakenStartup.ThirdParty.HereMap
{
    public class HereRoutingResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty("metaInfo")]
        public MetaInfo MetaInfo { get; set; }

        [JsonProperty("matrixEntry")]
        public List<MatrixEntry> MatrixEntry { get; set; }
    }

    public class MetaInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("mapVersion")]
        public string MapVersion { get; set; }

        [JsonProperty("moduleVersion")]
        public string ModuleVersion { get; set; }

        [JsonProperty("interfaceVersion")]
        public string InterfaceVersion { get; set; }

        [JsonProperty("availableMapVersion")]
        public List<string> AvailableMapVersion { get; set; }
    }

    public class MatrixEntry
    {
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("destinationIndex")]
        public int DestinationIndex { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public class Summary
    {
        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("travelTime")]
        public int TravelTime { get; set; }

        [JsonProperty("costFactor")]
        public int CostFactor { get; set; }
    }
}
