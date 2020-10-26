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
    [Authorize]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _service;

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVK)
    {
        try
        {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            newVK.CreatorId = userInfo.Id;
            
            return Ok(_service.Create(newVK));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id){
        try
        {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_service.Delete(id, userInfo.Id));

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
  }
}