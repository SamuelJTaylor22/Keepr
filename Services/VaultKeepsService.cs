using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vr;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vr)
    {
      _repo = repo;
      _vr = vr;
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
      Vault vault = _vr.GetById(newVK.VaultId);
      if(vault.CreatorId != newVK.CreatorId){ throw new Exception("you can't add keeps to other people's vaults");}
      newVK.Id = _repo.Create(newVK);
      return newVK;
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("You can only delete your own Keeps");}
      _repo.Delete(id);
      return "removed from list";
    }
  }
}