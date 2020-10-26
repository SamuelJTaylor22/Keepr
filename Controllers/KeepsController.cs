using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public ActionResult<Keep> GetOne(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_service.Create(newKeep, userInfo.Id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_service.Delete(id, userInfo.Id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}