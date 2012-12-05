using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Net.Http;
using Windows.Data.Xml.Dom;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.Generic;

namespace TileBackground
{
    public sealed class Class1 : IBackgroundTask
    {
        TileUpdater tileUpdater;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            tileUpdater.EnableNotificationQueue(true);
            AddTileNotification("Hey Everyone... Whats up", "tag1");
            AddTileNotification("Come see the new coffee shops", "tag2");
            AddTileNotification("I need caffine", "tag3");
            AddTileNotification("I drink coffee therfore I live", "tag4");
            AddTileNotification("Caffine Drip please", "tag5");
            GetData(); deferral.Complete();
        }

        private void AddTileNotification(string content, string tag)
        {
            var templateType = TileTemplateType.TileWideSmallImageAndText04;
            var xml = TileUpdateManager.GetTemplateContent(templateType);
            var textNodes = xml.GetElementsByTagName("text");
            textNodes[0].AppendChild(xml.CreateTextNode("A message"));
            textNodes[1].AppendChild(xml.CreateTextNode(content));
            var imageNodes = xml.GetElementsByTagName("image");
            var elt = (XmlElement)imageNodes[0];
            elt.SetAttribute("src", "ms-appx:///images/Coffee03.jpg");
            var tile = new TileNotification(xml);
            tile.Tag = tag;
            //tile.ExpirationTime = DateTimeOffset.Now.Add(new TimeSpan(0, 0, 20));  
            tileUpdater.Update(tile);
        }
        private async void GetData()
        {
            String _url = "http://www.iheartquotes.com/api/v1/random?format=json&max_lines=2&source=albert_einstein";
            var _Result = await CallService(new Uri(_url));
            if (_Result != null) AddTileNotification(_Result.quote, "tag new");
        }
        private async Task<RootObject> CallService(Uri uri)
        {
            string _JsonString = string.Empty;
            // fetch from rest service 

            var _HttpClient = new System.Net.Http.HttpClient();
            try
            {
                HttpResponseMessage _HttpResponse = _HttpClient.GetAsync(uri.ToString()).Result;
                _HttpResponse.EnsureSuccessStatusCode();
                _JsonString = await _HttpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                string test = ex.ToString();
            }
            // deserialize json to objects             
            var _JsonBytes = Encoding.Unicode.GetBytes(_JsonString);
            using (MemoryStream _MemoryStream = new MemoryStream(_JsonBytes))
            {
                var _JsonSerializer = new DataContractJsonSerializer(typeof(RootObject));
                var _Result = (RootObject)_JsonSerializer.ReadObject(_MemoryStream);
                return _Result;
            }
        }
    }
    public sealed class RootObject
    {
        public string json_class { get; set; }
        public IList<string> tags { get; set; }
        public string quote { get; set; }
        public string link { get; set; }
        public string source { get; set; }
    }
}
