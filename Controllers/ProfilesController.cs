using System;
using System.Collections.Generic;
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
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _ks;
    private readonly VaultsService _vs;
    public ProfilesController(ProfilesService ps, KeepsService ks, VaultsService vs)
    {
      _ps = ps;
      _ks = ks;
      _vs = vs;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    
    [HttpGet("{id}/keeps")]
    public ActionResult<Keep> GetKeepByUser(string id)
    {
      try
      {
        return Ok(_ks.GetByCreatorId(id)); 
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/vaults")]
    public ActionResult<Vault> GetVaultByUser(string id)
    {
      try
      {
        return Ok(_vs.GetByCreatorId(id)); 
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}