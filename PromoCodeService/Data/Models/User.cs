using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName) { }
        public User() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public ICollection<Promocode> Promocodes { get; set; } = new List<Promocode>();
    }
}
