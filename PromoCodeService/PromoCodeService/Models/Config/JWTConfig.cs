using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeService.Models.Config
{
    public class JWTConfig
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenLifeTime { get; set; }
        public int RefreshTokenLifeTime { get; set; }
    }
}
