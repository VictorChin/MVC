using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace BingMapServices.Controllers
{
    public class MapLocationController : ApiController
    {
        // GET api/<controller>
  
        // GET api/<controller>/5
       
        public async Task<string> Get(string address)
        {
            string bingkey = "AhGI6631iykKI0uHgJhK99EnFnGpP7W8z6rNS3FhY7GfWefmSGJ5a-Jgw_xXBfzA";
            string url = @"http://dev.virtualearth.net/REST/v1/Locations?postalCode={1}&key={0}";
            url = string.Format(url, bingkey, address);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonresult = await response.Content.ReadAsStringAsync();
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonresult);
                string coordinate = string.Format("Success:{0}:{1}", json.resourceSets[0].resources[0].point.coordinates[0], json.resourceSets[0].resources[0].point.coordinates[1]);
                return coordinate;
            }else
            { return "Bad Request"; }

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}