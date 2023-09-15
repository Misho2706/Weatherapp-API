using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Infrastructure.Models
{
    public class request_fore
    {
        [Key]
        public int id { get; set; }
        public string requestURL1 { get; set; }
        public Nullable<System.DateTime> date__1 { get; set; }
        public string city1 { get; set; }
        public string maxtemp { get; set; }
        public string mintemp { get; set; }
        public string weather_desc1 { get; set; }
        public string humidity1 { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }
}
