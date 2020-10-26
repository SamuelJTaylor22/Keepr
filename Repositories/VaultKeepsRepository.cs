using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
      private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
     string sql = @"
     INSERT INTO vaultkeeps
     (creatorId, vaultId, keepId)
     VALUES
     (@CreatorId, @VaultId, @KeepId);";
     _db.Execute(sql, newVK);
    return newVK;
    }
  }
}