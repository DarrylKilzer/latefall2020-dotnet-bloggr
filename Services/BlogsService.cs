using System;
using System.Collections;
using System.Collections.Generic;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Repositories;

namespace latefall2020_dotnet_bloggr.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }
        public Blog Create(Blog newBlog)
        {
            newBlog.Id = _repo.Create(newBlog);
            return newBlog;
        }

        public IEnumerable<Blog> Get()
        {
            return _repo.Get();
        }
    }
}