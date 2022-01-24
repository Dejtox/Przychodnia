using Microsoft.AspNetCore.Mvc;
using Przychodnia.Server.Models;
using Przychodnia.Server.Services;
using Przychodnia.Shared;

namespace Przychodnia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        private readonly IMailService MailService;

        public UsersController(IUserRepository UserRepository, IMailService MailService)
        {
            this.UserRepository = UserRepository;
            this.MailService = MailService;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<User>>> Search(string Name, string Surname)
        {
            try
            {
                var result = await UserRepository.Search(Name, Surname);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await UserRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await UserRepository.GetUser(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        ////nie działa xd
        //[HttpGet]
        //public async Task<ActionResult<User>> GetUserByMail([FromBody] string mail)
        //{
        //    try
        //    {
        //        var result = await UserRepository.GetUserByEmail(mail);

        //        if (result == null)
        //        {
        //            return NotFound();
        //        }

        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User User)
        {
            try
            {
                if (User == null)
                    return BadRequest();

                var emp = await UserRepository.GetUserByEmail(User.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("Email", "User email already in use");
                    return BadRequest(ModelState);
                }
                User.RangName = null;
                var createdUser = await UserRepository.AddUser(User);
                await MailService.sendEmail(User.Email, "Założono konto", Services.MailService.getMessageBody(MessageTypes.CreatedAccount, $"{User.Name} {User.Surname}"));

                return CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.ID }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new User record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User User)
        {
            try
            {
                if (id != User.ID)
                    return BadRequest("User ID mismatch");

                var UserToUpdate = await UserRepository.GetUser(id);

                if (UserToUpdate == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await UserRepository.UpdateUser(User);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating User record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var UserToDelete = await UserRepository.GetUser(id);

                if (UserToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                await UserRepository.DeleteUser(id);

                return Ok($"User with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting User record");
            }
        }
    }
}
