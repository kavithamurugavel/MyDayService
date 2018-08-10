using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDayService.Models;
using Newtonsoft.Json;

namespace MyDayService.Controllers
{
    [Produces("application/json")]
    [Route("api/Weather")]
    public class WeatherController : Controller
    {
        // GET: api/Weather
        [HttpGet]
        public WeatherRoot GetWeather(string zip)
        {
            string jsonString = "";
            string apiEndPoint = "http://api.openweathermap.org/data/2.5/weather?zip={0}&APPID={1}";
            string formattedAPI = string.Format(apiEndPoint, zip, "*******"); // TODO: hiding API key until encryption is coded
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(formattedAPI));
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponseAsync().Result;

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var weather = JsonConvert.DeserializeObject<WeatherRoot>(jsonString);
            return weather;
        }

        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Weather
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Weather/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
