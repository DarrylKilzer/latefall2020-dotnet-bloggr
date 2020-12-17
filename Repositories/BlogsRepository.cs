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

        internal IEnumerable<Blog> getBlogsByProfile(string profId)
        {
            string sql = @"
        SELECT
        blog.*,
        p.*
        FROM blogs blog
        JOIN profiles p ON blog.creatorId = p.id
        WHERE blog.creatorId = @profId; ";
            return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, new { profId }, splitOn: "id");
        }

        internal Blog GetOne(int id)
        {
            string sql = @"SELECT * from blogs WHERE id = @id";
            return _db.QueryFirstOrDefault<Blog>(sql, new { id });
        }

        internal void Edit(Blog editData)
        {
            string sql = @"
        UPDATE blogs
        SET
        body = @Body,
        title = @Title,
        isPublished = @IsPublished
        WHERE id = @Id;";
            _db.Execute(sql, editData);
        }

        public IEnumerable<Blog> Get()
        {
            string sql = populateCreator + "WHERE isPublished = 1";
            return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, splitOn: "id");
        }
    }
}