using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeService.Models.DTO
{
    public class ServiceSearchDTO
    {
        [Required]
        public string Name { get; set; }
        public bool FullMatch { get; set; } = true;
    }
}
