using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockFighter
{
    static class Paths
    {
        public static class PathParts
        {
            public const string VenueName = "venue";
            public const string StockName = "stock";
        }

        public const string VenueRoot = "ob/api/venues";
        public const string NamedVenue = VenueRoot + "/{" + PathParts.VenueName +"}";
        public const string StockRoot = NamedVenue + "/stocks";
        public const string NamedStock = StockRoot + "/{" + PathParts.StockName + "}";
        public const string StockQuote = NamedStock + "/quote";
        public const string StockOrder = NamedStock + "/orders";

        public static string ExpandPath(string path, Dictionary<string, string> expansions)
        {
            var expandedPath = path;
            foreach (var kv in expansions)
            {
                var name = string.Format("{{{0}}}", kv.Key);
                expandedPath = expandedPath.Replace(name, kv.Value);
            }
            return expandedPath;
        }
    }
}
