using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApiNet6.Data;
using DemoApiNet6.Domain;
using NuGet.Protocol;

namespace DemoApiNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaUsersController : ControllerBase
    {
        private readonly IUserRepository _IUserRepository;

        public SaUsersController(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }

        // GET: api/SaUsers
        [HttpGet]
        public async Task<IEnumerable<SaUser>> GetSaUsers()
        {
            return await _IUserRepository.GetAll();
        }

        // GET: api/SaUsers/usercode/password
        [HttpGet("{userCode}/{password}")]
        public async Task<ActionResult<SaUser>> GetLogin(string userCode, string password)
        {
            Encryption encryption = new Encryption();
            var passHash = encryption.Encrypt(password);
            var saUser = await _IUserRepository.GetLogin(userCode, passHash);
            if (saUser)
            {
                return Ok();
            }
            return BadRequest();
        }


        // GET: api/SaUsers/userCode
        [HttpGet("{userCode}")]
        public async Task<ActionResult<SaUser>> GetSaUserByUserCode(string userCode)
        {
            var user = await _IUserRepository.GetUserByUserCode(userCode);
            if (user != null)
            {
                return user;
            }
            return NotFound("User not found!");
        }

        // PUT: api/SaUsers/userCode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userCode}")]
        public async Task<IActionResult> PutSaUser(string userCode, SaUser saUser)
        {
           var user =  await _IUserRepository.UpdateAsnyc(userCode, saUser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(await _IUserRepository.GetAll());
        }

        // POST: api/SaUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaUser>> PostSaUser([FromBody]SaUser saUser)
        {
            Guid guid = Guid.NewGuid();
            Encryption encryption = new Encryption();
            var userVariable = await _IUserRepository.GetUserByUserCode(saUser.UserCode);
            try
            {
                if (saUser == null)
                    return BadRequest();
                if (userVariable != null)
                {
                    return BadRequest("User variable");
                }
                else
                {
                    saUser.RowId = guid;
                    saUser.PasswordHash = encryption.Encrypt(saUser.PasswordHash);
                    saUser.Inactive = true;
                    var createUser = await _IUserRepository.CreateUser(saUser);
                    return await _IUserRepository.GetUserByUserCode(saUser.UserCode);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }

        /* // DELETE: api/SaUsers/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteSaUser(string id)
         {
             var saUser = await _context.SaUsers.FindAsync(id);
             if (saUser == null)
             {
                 return NotFound();
             }

             _context.SaUsers.Remove(saUser);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool SaUserExists(string id)
         {
             return _context.SaUsers.Any(e => e.UserCode == id);
         }*/
    }
}
