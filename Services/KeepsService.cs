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
  }
}