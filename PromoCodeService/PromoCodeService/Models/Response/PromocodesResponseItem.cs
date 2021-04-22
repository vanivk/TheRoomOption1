using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeService.Models.Response
{
    public class PromocodesResponseItem
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool Activated { get; set; }

        public PromocodesResponseItem(Promocode promocode, bool activated = false)
        {
            Id = promocode.Id;
            ServiceId = promocode.ServiceId;
            Description = promocode.Description;
            Code = promocode.Code;
            Activated = activated;
        }
    }
}
