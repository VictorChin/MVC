using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading.Tasks;

namespace BingMapServices
{
 
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LocationService : ILocationService
    {
        string bingkey = "AhGI6631iykKI0uHgJhK99EnFnGpP7W8z6rNS3FhY7GfWefmSGJ5a-Jgw_xXBfzA";

        
        public async Task<string> GetLocationByZip(string zip)
        {
            string url = @"http://dev.virtualearth.net/REST/v1/Locations?postalCode={1}&key={0}";

            // Add your operation implementation here
            return await getCoordinate(url, zip);
        }
        public async Task<string> GetLocationByLocality(string locality)
        {
            locality = locality.Replace(',', ' ');
            string url = @"http://dev.virtualearth.net/REST/v1/Locations?locality={1}&maxResults=1&key={0}";

            // Add your operation implementation here
            return await getCoordinate(url, locality);
        }

        private async Task<string> getCoordinate(string url,string input)
        {
            url = string.Format(url, bingkey, input);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonresult = await response.Content.ReadAsStringAsync();
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonresult);

                if (json.resourceSets[0].estimatedTotal != 0)
                {
                    string coordinate = string.Format("Success:{0}:{1}", json.resourceSets[0].resources[0].point.coordinates[0], json.resourceSets[0].resources[0].point.coordinates[1]);
                    return coordinate;
                }
                else
                { return "No Result"; }
                
            }
            else
            { return "Bad Request"; }
        }
        // Add more operations here and mark them with [OperationContract]
    }
}
