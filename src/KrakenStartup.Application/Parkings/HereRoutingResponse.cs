using System;
using System.Collections.Generic;
using System.Text;

namespace KrakenStartup.Parkings
{
    public class HereRoutingResponse
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public MetaInfo metaInfo { get; set; }
        public List<MatrixEntry> matrixEntry { get; set; }
    }

    public class MetaInfo
    {
        public DateTime timestamp { get; set; }
        public string mapVersion { get; set; }
        public string moduleVersion { get; set; }
        public string interfaceVersion { get; set; }
        public List<string> availableMapVersion { get; set; }
    }

    public class MatrixEntry
    {
        public int startIndex { get; set; }
        public int destinationIndex { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public int costFactor { get; set; }
    }
}
