using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db; 
    private readonly string populateCreator = @"SELECT 
    blog.*,
    profile.* 
    FROM blogs blog 
    JOIN profiles profile on blog.creatorEmail = profile.email ";

    public KeepsRepository(IDbConnection db, string populateCreator)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = populateCreator;
      return  _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {keep.Creator = profile; return keep;}, splitOn: "id");
    }
  }
}