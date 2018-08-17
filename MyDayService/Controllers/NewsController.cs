using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDayService.Models.News;
using Newtonsoft.Json;

namespace MyDayService.Controllers
{
    [Produces("application/json")]
    [Route("api/News")]
    public class NewsController : Controller
    {
        // GET: api/News
        [HttpGet]
        public NewsRoot GetNews(string topic)
        {
            string jsonString = "";
            string formattedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string apiKey = "*******"; // TODO: hiding API key until encryption is coded
            string apiEndPoint = "https://newsapi.org/v2/everything?q={0}&from={1}&to={1}&sortBy=popularity&apiKey={2}";
            string formattedAPI = string.Format(apiEndPoint, topic, formattedDate, apiKey); 
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(formattedAPI));
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponseAsync().Result;

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var news = JsonConvert.DeserializeObject<NewsRoot>(jsonString);
            return news;
        }

        // Commenting for now since it was throwing exception. TODO: fix this
        // GET: api/News/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/News
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/News/5
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
