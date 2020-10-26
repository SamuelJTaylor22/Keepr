using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db; 
    private readonly string populateCreator = @"SELECT 
    vault.*,
    profile.* 
    FROM vaults vault 
    JOIN profiles profile on vault.creatorId = profile.id
    ";

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault GetById(int id)
    {
      string sql = populateCreator + "WHERE vault.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {vault.Creator = profile; return vault;}, new {id}, splitOn: "id").FirstOrDefault();
    }

    internal IEnumerable<Vault> GetAll()
    {
      string sql = populateCreator;
      return  _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {vault.Creator = profile; return vault;}, splitOn: "id");
    }

    internal int Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (creatorId, name, description, isprivate)
      VALUES
      (@CreatorId, @Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal IEnumerable<Vault> GetByCreatorId(string id)
    {
      string sql = populateCreator + "WHERE creatorId = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {vault.Creator = profile; return vault;}, new {id}, splitOn: "id");
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new{id});
    }

    internal Vault Edit(Vault editVault)
    {
      string sql = @"
      UPDATE vaults
      SET
      name = @Name,
      description = @Description,
      isprivate = @IsPrivate,
      WHERE id = @id;";
      _db.Execute(sql, editVault);
      return editVault;
    }
  }
}