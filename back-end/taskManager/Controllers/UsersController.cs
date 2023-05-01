using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;

namespace task_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;


        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {

                _logger.LogInformation("==============GET api/users/GetAllUsers================");
                var users = await _context.Users.AsNoTracking().ToListAsync();

                if (users is null)
                {
                    return NotFound();
                }

                return Ok(users);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }

            
        }

        [HttpGet]
        [Route("GetUserById/{userId:guid}")]
        public async Task<ActionResult<User>> GetUserById(string userId)
        {
            try
            {
                var user = await _context.Users.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.UserId.ToString() == userId);

                if (user is null)
                {
                    return NotFound("Usuário não encontrado");
                }

                return Ok(user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }


        }

        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult<User> RegisterUser(string name, string email, string password, string role, DateTime registerDate)
        {

            try
            {
                var newUser = new User
                {
                    UserId = new Guid(),
                    Name = name,
                    Email = email,
                    Password = password,
                    Role = role,
                    RegisterDate = registerDate
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return Created("RegisterUser", newUser);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }

            
        }

        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public ActionResult<User> UpdateUser(string userId, User user)
        {
            try
            {
                if (user.UserId.ToString() != userId)
                {
                    return BadRequest("Ids não equivalentes");
                }


                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public ActionResult DeleteUser(string userId)
        {

            try
            {
                var deletedUser = _context.Users.FirstOrDefault(x => x.UserId.ToString() == userId);

                if (deletedUser is null)
                {
                    return NotFound("Produto não localizado");
                }

                _context.Users.Remove(deletedUser);
                _context.SaveChanges();

                return Ok(deletedUser);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }
        }
    }
}
