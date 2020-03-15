using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatesTestTask.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatesTestTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DatesController> _logger;

        public DatesController(ILogger<DatesController> logger)
        {
            _logger = logger;
        }

       
        [HttpGet("")]
        public IEnumerable<DatesRange> Get()
        {
            
            return Ok();

        }
    }
}
