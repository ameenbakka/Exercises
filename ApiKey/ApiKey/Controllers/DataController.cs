using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "ReadOnly")]
        public IActionResult GetData()
        {
            return Ok("GET: Read-only data");
        }

        [HttpPost]
        [Authorize(Policy = "WriterOnly")]
        public IActionResult PostData()
        {
            return Ok("POST: Data written");
        }

        [HttpDelete]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteData()
        {
            return Ok("DELETE: Admin only");
        }

    }
}
