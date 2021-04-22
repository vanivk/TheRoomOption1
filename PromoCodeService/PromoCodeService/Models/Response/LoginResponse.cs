using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeService.Models.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expires {get; set; }
        public string RefreshToken {get; set; }
    }
}
