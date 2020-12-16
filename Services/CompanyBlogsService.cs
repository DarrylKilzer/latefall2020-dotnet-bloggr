using System;
using System.Collections.Generic;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Repositories;

namespace latefall2020_dotnet_bloggr.Services
{
  public class CompanyBlogsService
  {

    private readonly CompanyBlogsRepository _repo;

    public CompanyBlogsService(CompanyBlogsRepository repo)
    {
      _repo = repo;
    }

    public CompanyBlog Create(CompanyBlog newCb)
    {
      newCb.Id = _repo.Create(newCb);
      return newCb;
    }

    internal IEnumerable<Blog> GetBlogsByCompanyId(int companyId)
    {
      return _repo.GetBlogsByCompanyId(companyId);

    }

    internal string Delete(int id, string userId)
    {
      CompanyBlog original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad Id"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Not the User : Access Denied");
      }
      if (_repo.Remove(id))
      {
        return "deleted succesfully";
      }
      return "did not remove succesfully";
    }
  }
}