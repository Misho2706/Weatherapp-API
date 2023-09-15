using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/design")]
    [ApiController]
    public class AppDesignController : ControllerBase
    {
        [HttpGet]
        [Route("convertunits")]
        public static string convertUnitsTemp(string str, bool toggleSwitchUnits)
        {
            if (!toggleSwitchUnits == true)
            {
                str = str + "C";
                
            }
            else
            {
                str = str + "F";

            }
            return str;
        }

        [HttpGet]
        [Route("convertunix")]

        public static DateTime ConvertFromUnix(long timestamp, bool local = false)
        {
            var offset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return local ? offset.LocalDateTime : offset.UtcDateTime;
        }
    }
    
}
