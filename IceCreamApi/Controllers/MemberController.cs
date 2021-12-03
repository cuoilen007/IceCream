using IceCreamApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        projectContext db = new projectContext();

        public MemberController(projectContext db)
        {
            this.db = db;
        }

        [HttpGet("Login/{username}/{password}")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var foundMember = await db.Members.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (foundMember == null)
            {
                return NotFound();
            }
            return Ok(foundMember);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(Member member)
        {
            if (member == null)
            {
                return NotFound();
            }
            member.RegisterDay = DateTime.Now;       
            member.IsMember = true;
            db.Members.Add(member);
            await db.SaveChangesAsync();
            return Ok(member);                                          
        }
    }
}
