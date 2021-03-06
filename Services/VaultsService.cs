using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
      private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Vault> GetAll(string userId)
    {
      IEnumerable<Vault> vaults = _repo.GetAll();
      return vaults.ToList().FindAll(v => v.CreatorId == userId || v.IsPrivate);
    }

    internal Vault GetById(int id, string userId)
    {
      Vault found = _repo.GetById(id);
      if (found == null) {throw new Exception("Invalid Id");}
      if(found.IsPrivate == true && found.CreatorId != userId){throw new Exception("This Vault is Private");}
      return found;
    }

    internal object Create(Vault newVault, string userId)
    {
      newVault.CreatorId = userId;
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal object Delete(int id, string userId)
    {
      Vault original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("You can only delete your own Vaults");}
      _repo.Delete(id);
      return "Its gone";
    }

    internal IEnumerable<Vault> GetByCreatorId(string id, string userId)
    {
      IEnumerable<Vault> vaults = _repo.GetByCreatorId(id);
      return vaults.ToList().FindAll(v => v.CreatorId == userId || !v.IsPrivate);
    }

    internal object Edit(Vault editVault, string id)
    {
      Vault original = _repo.GetById(editVault.Id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != id) { throw new Exception("You may only edit your own Vaults");}
      editVault.Name = editVault.Name == null ? original.Name : editVault.Name;
      editVault.Description = editVault.Description == null ? original.Description : editVault.Description;
      return _repo.Edit(editVault);
    }
  }
}