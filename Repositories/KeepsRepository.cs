using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db; 
    private readonly string populateCreator = @"SELECT 
    keep.*,
    profile.* 
    FROM keeps keep 
    JOIN profiles profile on keep.creatorId = profile.id
    ";

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Keep GetById(int id)
    {
      string sql = populateCreator + "WHERE keep.id = @id";
    //   Keep found = _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id").FirstOrDefault();
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, new {id}, splitOn: "id").FirstOrDefault();
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = populateCreator;
      return  _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id");
    }

    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (creatorId, name, description, img)
      VALUES
      (@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new{id});
    }
  }
}