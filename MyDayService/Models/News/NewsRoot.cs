using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayService.Models.News
{
    public class NewsRoot
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}
