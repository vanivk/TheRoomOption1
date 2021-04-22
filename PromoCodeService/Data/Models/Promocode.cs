using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Promocode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? AvailableTill { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();
        public int ServiceId { get; set; }
    }
}
