using System;

namespace Data.Models
{
    public class UserPromocode
    {
        public string UserId { get; set; }
        public int PromocodeId { get; set; }
        public DateTime DateActivated { get; set; }
    }
}
