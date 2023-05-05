using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;
using task_manager.DTOs;
using task_manager.Repository;

namespace task_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public UsersController(IUnitOfWork context, ILogger<UsersController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {

                _logger.LogInformation("==============GET api/users/GetAllUsers================");
                var users = _context.UserRepository.Get().ToList();

                if (users is null)
                {
                    return NotFound();
                }

                var usersDto = _mapper.Map<List<UserDTO>>(users);

                return Ok(usersDto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }

            
        }

        [HttpGet]
        [Route("GetUserById/{userId:guid}")]
        public ActionResult<UserDTO> GetUserById(string userId)
        {
            try
            {
                var user = _context.UserRepository.GetById(x => x.UserId.ToString() == userId);

                if (user is null)
                {
                    return NotFound("Usuário não encontrado");
                }

                var userDto = _mapper.Map<UserDTO>(user);

                return Ok(userDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult<User> RegisterUser([FromBody] User user)
        {

            try
            {
                _context.UserRepository.Add(user);
                _context.Commit();

                return Created("RegisterUser", user);
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

                _context.UserRepository.Update(user);
                _context.Commit();

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
                var deletedUser = _context.UserRepository.GetById(x => x.UserId.ToString() == userId);

                if (deletedUser is null)
                {
                    return NotFound("Produto não localizado");
                }

                _context.UserRepository.Delete(deletedUser);
                _context.Commit();

                return Ok(deletedUser);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }
        }
    }
}
