using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatesTestTask.Core;
using DatesTestTask.Services;
using DatesTestTask.Services.DTO;
using DatesTestTask.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatesTestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatesController : ControllerBase
    {
        private readonly IDatesService _datesService;
        public DatesController(IDatesService datesService)
        {
            _datesService = datesService;
        }
                
        [HttpGet("GetRanges")]
        public async Task<List<DatesRange>> Get([FromQuery]DatesRangeDTO datesRangeDTO)
        {
           return await _datesService.GetRangesAsync(datesRangeDTO);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRange([FromBody]DatesRangeDTO _datesRangeDTO)
        {
            await _datesService.CreateRangeAsync(_datesRangeDTO);
            return Ok();
        }
    }
}
