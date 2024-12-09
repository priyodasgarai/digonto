using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace digonto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyHomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(){
            return Ok("ApiTest priyo");
        }
    }
}