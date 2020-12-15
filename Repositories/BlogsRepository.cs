using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latefall2020_dotnet_bloggr.Models;

namespace latefall2020_dotnet_bloggr.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;
        private readonly string populateCreator = "SELECT blog.*, profile.* FROM blogs blog INNER JOIN profiles profile ON blog.creatorId = profile.id ";

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }
        public int Create(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs 
            (title, body, creatorId, isPublished)
            VALUES
            (@Title, @Body, @CreatorId, @IsPublished);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newBlog);
        }

        public IEnumerable<Blog> Get()
        {
            string sql = populateCreator + "WHERE isPublished = 1";
            return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, splitOn: "id");
        }
    }
}