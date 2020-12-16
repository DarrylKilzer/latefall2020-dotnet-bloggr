using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace latefall2020_dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompanyBlogsController : ControllerBase
  {
    private readonly CompanyBlogsService _cbs;

    public CompanyBlogsController(CompanyBlogsService cbs)
    {
      _cbs = cbs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CompanyBlog>> Post([FromBody] CompanyBlog newCb)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newCb.CreatorId = userInfo.Id;
        return Ok(_cbs.Create(newCb));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_cbs.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);

      }
    }

  }
}