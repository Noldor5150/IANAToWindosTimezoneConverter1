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
        [HttpGet]
        public Response Post1([FromBody] Request data)
        {
            return converter.ConvertFromIanaTz(data);
        }

        [Route("/windows")]
        [HttpGet]
        public Response Post([FromBody] Request data)
        {
            return converter.ConvertFromWindosTz(data);
        }

        [Route("/dateTime")]
        [HttpGet]
        public Response Post([FromBody] DateTimeRequest data)
        {
            return converter.ConvertDateTime(data);
        }
    }
}