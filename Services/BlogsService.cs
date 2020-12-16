using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    internal IEnumerable<Blog> GetBlogsByProfile(string profId, string userId)
    {
      return _repo.getBlogsByProfile(profId).ToList().FindAll(b => b.CreatorId == userId || b.IsPublished);
    }

    internal Blog Edit(Blog editData, string userId)
    {
      Blog original = _repo.GetOne(editData.Id);
      if (original == null) { throw new Exception("Bad Id"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Not the User : Access Denied");
      }
      _repo.Edit(editData);

      return _repo.GetOne(editData.Id);

    }
  }
}