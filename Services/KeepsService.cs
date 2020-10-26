using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
      private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
    }

    internal Keep GetById(int id)
    {
      Keep found = _repo.GetById(id);
      found.Views = found.Views + 1;
      if (found == null) {throw new Exception("Invalid Id");}
      return found;
    }

    internal object Create(Keep newKeep, string userId)
    {
      newKeep.CreatorId = userId;
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal object Delete(int id, string userId)
    {
      Keep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != userId) { throw new Exception("You can only delete your own Keeps");}
      _repo.Delete(id);
      return "Its gone";
    }

    internal IEnumerable<Keep> GetByCreatorId(string id)
    {
      return _repo.GetByCreatorId(id);
    }

    internal object Edit(Keep editKeep, string id)
    {
      Keep original = _repo.GetById(editKeep.Id);
      if (original == null) { throw new Exception("Invalid Id"); }
      if (original.CreatorId != id) { throw new Exception("You may only edit your own Keeps");}
      editKeep.Name = editKeep.Name == null ? original.Name : editKeep.Name;
      editKeep.Description = editKeep.Description == null ? original.Description : editKeep.Description;
      editKeep.Img = editKeep.Img == null ? original.Img : editKeep.Img;

      return _repo.Edit(editKeep);
    }

    internal IEnumerable<KeepViewModel> GetKeepsByVault(int id)
    {
      return _repo.GetKeepsByVault(id);
    }
  }
}