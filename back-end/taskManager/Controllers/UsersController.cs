﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager.Context;
using task_manager.Domain;
using task_manager.DTOs;
using task_manager.Extensions;
using task_manager.Repository;
using task_manager.Response;

namespace task_manager.Controllers
{
    [Authorize]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllUsers/{pageNumber}/{pageSize}")]
        public async Task<ResponseResult> GetAllUsers(int pageNumber, int pageSize)
        {
            try
            {

                _logger.LogInformation("==============GET api/users/GetAllUsers================");
                var users = _context.UserRepository.Get();

                if (users is null)
                {
                    return ResponseResult.ReturnNotFound("No users found", users);
                }

                users = users.Pagination(pageNumber, pageSize);
                var count = await users.CountAsync();
                var usersDto = _mapper.Map<List<UserDTO>>(users);

                return ResponseResult.ReturnSuccess("Request Successful", new PaginationDTO<UserDTO>(count, pageSize, pageNumber, usersDto));


            }
            catch (Exception)
            {

                return ResponseResult.ReturnError("Ocorreu um problema ao tratar sua solicitação");
                    
            }

            
        }

        [HttpGet]
        [Route("GetUserById/{userId:guid}")]
        public async Task<ResponseResult> GetUserById(string userId)
        {
            try
            {
                var user = await _context.UserRepository.GetById(x => x.UserId.ToString() == userId);

                if (user is null)
                {
                    return ResponseResult.ReturnNotFound("No users found", user);
                }

                var userDto = _mapper.Map<UserDTO>(user);

                return ResponseResult.ReturnSuccess("Request Successful", userDto);
            }
            catch (Exception)
            {

                return ResponseResult.ReturnError("Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {

            try
            {
                _context.UserRepository.Add(user);
                await _context.Commit();

                return Created("RegisterUser", user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }

            
        }

        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public async Task<ActionResult<User>> UpdateUser(string userId, User user)
        {
            try
            {
                if (user.UserId.ToString() != userId)
                {
                    return BadRequest("Ids não equivalentes");
                }

                _context.UserRepository.Update(user);
                await _context.Commit();

                return Ok(user);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação");
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {

            try
            {
                var deletedUser = await _context.UserRepository.GetById(x => x.UserId.ToString() == userId);

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
