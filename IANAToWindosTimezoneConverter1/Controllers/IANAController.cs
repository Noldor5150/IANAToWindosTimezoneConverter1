using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IANAToWindosTimezoneConverter1.Models;
using IANAToWindosTimezoneConverter1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace IANAToWindosTimezoneConverter1.Controllers
{
    
    [ApiController]
    public class IANAController : ControllerBase
    {

        private readonly ConverterService converter;
        public IANAController()
        {
            converter = new ConverterService();
        }

        [Route("/iana")]
        [HttpPost]
        public Response Post1([FromBody] Request data)
        {
            return converter.ConvertFromIanaTz(data);
        }

        [Route("/windows")]
        [HttpPost]
        public Response Post([FromBody] Request data)
        {
            return converter.ConvertFromWindosTz(data);
        }

        [Route("/dateTime")]
        [HttpPost]
        public Response Post([FromBody] DateTimeRequest data)
        {
            return converter.ConvertDateTime(data);
        }
    }
}