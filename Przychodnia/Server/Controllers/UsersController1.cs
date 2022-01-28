using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Przychodnia.Server.Models;
using Przychodnia.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
/*
namespace Przychodnia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDb _context;

        public UsersController(AppDb context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Users.FirstOrDefaultAsync(a => a.ID == id);
            return Ok(dev);
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user.ID);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new User { ID = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}*/