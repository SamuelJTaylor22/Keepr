using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vr;
      private readonly KeepsRepository _kr;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vr, KeepsRepository kr)
    {
      _repo = repo;
      _vr = vr;
      _kr = kr;
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
      Vault vault = _vr.GetById(newVK.VaultId);
      if(vault.CreatorId != newVK.CreatorId){ throw new Exception("you can't add keeps to other people's vaults");}
      Keep keep = _kr.GetById(newVK.KeepId);
      keep.Keeps = keep.Keeps+1;
      _kr.Edit(keep);
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