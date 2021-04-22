using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RefreshToken
    {
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public DateTime Expires { get; set; }
        public string UserAgent { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public bool Expired => Expires.CompareTo(DateTime.Now) < 0;
    }
}
