using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Infrastructure.Models
{
    public class Users
    {
        [Key] public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public Nullable<int> role_id { get; set; }
    }
}
