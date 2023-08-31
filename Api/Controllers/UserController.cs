using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

/// <summary>
/// Classe para gerenciar as requisições de usuário.
/// </summary>
[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserService<LoginUserDto> _userService;
    public UserController(IUserService<LoginUserDto> userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Loga um usuário no sistema.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para realizar o login.</param>
    /// <returns>Retorna um Task de IActionResult que possui o token de login do usuário.</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        try
        {
            var token = await _userService.Login(dto);
            return Ok(token);
        }
        catch(Exception exception)
        {
            return Problem(exception.Message);
        }               
    }

    /// <summary>
    /// Registra um usuário no banco de dados.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para registrar o usuário.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja concluída com sucesso.</response>
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterUser(CreateUserDto dto)
    {
        try
        {
            var user = await _userService.Create(dto);
            return Ok(user);
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }
    }
}
