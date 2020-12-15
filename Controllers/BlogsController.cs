using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using latefall2020_dotnet_bloggr.Models;
using latefall2020_dotnet_bloggr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace latefall2020_dotnet_bloggr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _bs;

        public BlogsController(BlogsService bs)
        {
            _bs = bs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newBlog.CreatorId = userInfo.Id;
                Blog created = _bs.Create(newBlog);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_bs.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}