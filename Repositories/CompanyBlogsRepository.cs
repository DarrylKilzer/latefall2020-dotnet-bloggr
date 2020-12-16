using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latefall2020_dotnet_bloggr.Models;

namespace latefall2020_dotnet_bloggr.Repositories
{
  public class CompanyBlogsRepository
  {
    private readonly IDbConnection _db;

    public CompanyBlogsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(CompanyBlog newCb)
    {
      string sql = @"
        INSERT INTO companyblogs
        (companyId, blogId, creatorId)
        VALUES
        (@CompanyId, @BlogId, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCb);
    }

    internal IEnumerable<Blog> GetBlogsByCompanyId(int companyId)
    {
      string sql = @"
        SELECT b.*,
        cb.id as CompanyBlogId,
        p.*
        FROM companyblogs cb
        JOIN blogs b ON b.id = cb.blogId
        JOIN profiles p ON p.id = b.creatorId
        WHERE companyId = @companyId;";
      return _db.Query<CompanyBlogViewModel, Profile, CompanyBlogViewModel>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, new { companyId }, splitOn: "id");
    }

    internal bool Remove(int id)
    {
      string sql = "DELETE from companyblogs WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal CompanyBlog Get(int id)
    {
      string sql = @"SELECT * from companyblogs WHERE id = @id";
      return _db.QueryFirstOrDefault<CompanyBlog>(sql, new { id });
    }
  }
}