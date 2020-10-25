using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _service;

        public KeepsController(KeepsService ks)
        {
            _service = ks;
        }
        [HttpGet]
        public ActionResult<Keep> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}