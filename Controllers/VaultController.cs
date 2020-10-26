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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _service;

        public VaultsController(VaultsService ks)
        {
            _service = ks;
        }
        [HttpGet]
        public ActionResult<Vault> Get()
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
        public ActionResult<Vault> GetOne(int id)
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
        [HttpPut("{id}")]
        public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editVault){
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editVault.CreatorId= userInfo.Id;
                editVault.Creator = userInfo;
                editVault.Id = id;
                
                return Ok(_service.Edit(editVault, userInfo.Id));
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_service.Create(newVault, userInfo.Id));
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