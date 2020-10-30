using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ContentService.API.Context;
using ContentService.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentService.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private DataContext _context;

        public ContentController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("posts")]
        public async Task<Object> GetLastTenPosts()
        {
            var allPost = _context.Posts.Where(p => p.published == true).OrderBy(u => u.createDate).Take(10);
            var sortPost = allPost.ToList();
            return Ok(sortPost);
        }



    }
}
