using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win8CoffeeXAML.Model
{
    public class ResultSet
    {
        public string totalResultsAvailable { get; set; }
        public string totalResultsReturned { get; set; }
        public string firstResultPosition { get; set; }
        public string ResultSetMapUrl { get; set; }
        public List<Result> Result { get; set; }
    }
}
