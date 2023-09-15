using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Infrastructure.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string role1 { get; set; }
    }
}
