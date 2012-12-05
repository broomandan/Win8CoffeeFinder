using System.Runtime.Serialization.Json;
using win8CoffeeXAML.Model;
using Windows.Devices.Geolocation;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;



namespace win8CoffeeXAML.ViewModel
{
    public class ResultsModel : BaseViewModel
    {
        private Geoposition pos;
        private readonly string apiKey = "zRpn9UPV34FcirmbMobT.sxtRRZdAgrQ0pyG7_fMggwGHw03Fzbh3YneJN0osAg9iYzNdq2RzoOOhn9CwdBoYXRDsWIW1OA-";

        public ResultsModel()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                GetLocation();
        }

        private async Task<List<Result>> GetData()
        {
            String _url = string.Format("http://local.yahooapis.com/LocalSearchService/V3/localSearch?output=json&appid={0}&query=coffee&results=20&start=1&latitude={1}&longitude={2}", apiKey, pos.Coordinate.Latitude.ToString(), pos.Coordinate.Longitude.ToString());
            var _Result = await CallService(new Uri(_url));

            if (_Result == null) return null;
            return _Result.ResultSet.Result;
        }
        private async Task<RootObject> CallService(Uri uri)
        {
            string _JsonString = string.Empty;
            // fetch from rest service             
            var _HttpClient = new System.Net.Http.HttpClient();
            var _HttpResponse = await _HttpClient.GetAsync(uri.ToString());
            _JsonString = await _HttpResponse.Content.ReadAsStringAsync();
            // deserialize json to objects        
            var _JsonBytes = Encoding.Unicode.GetBytes(_JsonString);
            using (MemoryStream _MemoryStream = new MemoryStream(_JsonBytes))
            { var _JsonSerializer = new DataContractJsonSerializer(typeof(RootObject)); var _Result = (RootObject)_JsonSerializer.ReadObject(_MemoryStream); return _Result; }
        }
        private async void GetLocation()
        {
            int img = 1;

            this.Results = new System.Collections.ObjectModel.ObservableCollection<Result>();
            Geolocator geo = new Geolocator();
            pos = await geo.GetGeopositionAsync();
            var data = await GetData();
            foreach (Result r in data)
            {
                if (img > 9)
                {
                    r.Image = "images/Coffee" + img + ".jpg";
                }
                else
                {
                    r.Image = "images/Coffee0" + img + ".jpg";
                }
                this.Results.Add(r);
                img++;
            }
        }
    }
}
