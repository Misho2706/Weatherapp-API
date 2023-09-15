using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Infrastructure.Models
{
    public class request_history
    {
        [Key]
        public int id { get; set; }
        public string requestURL { get; set; }
        public DateTime? date__ { get; set; }
        public string city { get; set; }
        public string temperature { get; set; }
        public string weather_desc { get; set; }
        public string humidity { get; set; }
        public string chance_of_rain { get; set; }
    }
}
