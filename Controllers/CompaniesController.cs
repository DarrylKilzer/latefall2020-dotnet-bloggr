using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace latefall2020_dotnet_Companygr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    private readonly CompaniesService _cs;
    private readonly CompanyBlogsService _cbs;
    public CompaniesController(CompaniesService cs, CompanyBlogsService cbs)
    {
      _cs = cs;
      _cbs = cbs;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Company> Create([FromBody] Company newCompany)
    {
      try
      {
        Company created = _cs.Create(newCompany);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Company>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{companyId}/companyblogs")]
    public ActionResult<IEnumerable<Blog>> Get(int companyId)
    {
      try
      {
        return Ok(_cbs.GetBlogsByCompanyId(companyId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}