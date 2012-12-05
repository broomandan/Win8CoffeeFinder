using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win8CoffeeXAML.Model
{
    public class Result
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Rating Rating { get; set; }
        public string Distance { get; set; }
        public string Url { get; set; }
        public string ClickUrl { get; set; }
        public string MapUrl { get; set; }
        public string BusinessUrl { get; set; }
        public string BusinessClickUrl { get; set; }
        public Categories Categories { get; set; }
        public string Image { get; set; }

    }
}
