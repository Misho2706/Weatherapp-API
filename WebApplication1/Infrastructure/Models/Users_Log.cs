using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Infrastructure.Models
{
    public class Users_Log
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
    }
}
