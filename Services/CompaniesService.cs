using System;
using System.Collections;
using System.Collections.Generic;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Repositories;

namespace latefall2020_dotnet_bloggr.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _repo;

    public CompaniesService(CompaniesRepository repo)
    {
      _repo = repo;
    }
    public Company Create(Company newCompany)
    {
      newCompany.Id = _repo.Create(newCompany);
      return newCompany;
    }

    public IEnumerable<Company> Get()
    {
      return _repo.Get();
    }
  }
}