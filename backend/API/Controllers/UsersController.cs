using API.DTOs;
using API.Services;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Corer.Helpers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly UserDTOService _userDTOService;

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, UserDTOService userDTOService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userRepository = userRepository;
        _userDTOService = userDTOService;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Auth(string usr, string psw)
    {
        try
        {
            var user = await _userRepository.GetByUsrAsync(usr);

            if (user is null)
            {
                Log.Logger.Information("Intento de inicio de sesión fallido para el usuario: " + usr);
                return Unauthorized(new { Code = 1, Message = "Invalid username or password" });
            }

            // Verify if the provided password matches the stored hash
            var isAuthenticated = PasswordHasher.VerifyPassword(psw, user.Password);

            if (!isAuthenticated)
            {
                Log.Logger.Error("Intento de inicio de sesión fallido para el usuario: " + usr);
                return Unauthorized(new { Code = 1, Message = "Invalid username or password" });
            }

            Log.Logger.Information($"Usuario '{usr}' autenticado correctamente.");
            return Ok(new { Code = 0, Message = "User authenticated successfully" });

        }
        catch (Exception ex)
        {
            var message = "There was an issue authenticating the user. Please try again later.";
            Log.Logger.Error(message, ex);

            return StatusCode(500, new { Message = message, Details = ex.Message });
        }
    }

    [HttpGet("dto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userDTOService.GetAllUsers();

        if (users is null)
            return NotFound();

        return Ok(users);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<List<User>>(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user is null)
            return NotFound();

        return _mapper.Map<User>(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(User oRent)
    {
        var msg = string.Empty;
        try
        {
            var user = _mapper.Map<User>(oRent);
            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveAsync();

            if (user is null)
                return BadRequest();

            oRent.Id = user.Id;

            object[] obj = new object[] { user.Id, user.Name };
            msg = string.Format(Constants.MSG_USER_ADDED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return CreatedAtAction(nameof(Post), new { id = oRent.Id }, oRent);
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_USER_ADDED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Put([FromBody] User oUser)
    {
        var msg = string.Empty;
        try
        {
            if (oUser is null)
                return NotFound();

            var user = _mapper.Map<User>(oUser);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveAsync();

            object[] obj = new object[] { user.Id, user.Name };
            msg = string.Format(Constants.MSG_USER_UPDATED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return oUser;
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_USER_UPDATED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var msg = string.Empty;
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveAsync();

            object[] obj = new object[] { user.Id, user.Name };
            msg = string.Format(Constants.MSG_USER_DELETED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return NoContent();
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_USER_DELETED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }
}