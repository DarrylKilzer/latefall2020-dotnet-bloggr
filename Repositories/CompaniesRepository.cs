using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latefall2020_dotnet_bloggr.Models;
namespace latefall2020_dotnet_bloggr.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;
    // private readonly string populateCreator = "SELECT blog.*, profile.* FROM blogs blog INNER JOIN profiles profile ON blog.creatorId = profile.id ";

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Company newCompany)
    {
      string sql = @"
            INSERT INTO companies 
            (name, address)
            VALUES
            (@Name, @Address);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCompany);
    }

    public IEnumerable<Company> Get()
    {
      string sql = "SELECT * from companies";
      return _db.Query<Company>(sql);
    }
  }
}