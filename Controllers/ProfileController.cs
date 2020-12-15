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
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfilesService _ps;

        public ProfileController(ProfilesService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Profile>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}