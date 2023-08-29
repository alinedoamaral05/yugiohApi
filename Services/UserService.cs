﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Services;

public class UserService : IUserService<LoginUserDto>
{
    private IMapper _mapper;
    private SignInManager<User> _signInManager;
    private UserManager<User> _userManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, TokenService tokenService)
    {
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<ReadUserDto> Create(CreateUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new Exception("User creation failed! Please check user details and try again.");
        }

        var readDto = _mapper.Map<ReadUserDto>(user);

        return readDto;
    }

    public async Task DeleteById(string id)  
    {
        var usuario = await _signInManager
            .UserManager
            .Users
            .FirstOrDefaultAsync(user => user.Id == id);

        if (usuario == null) throw new Exception("user not found");

        await _signInManager.UserManager.DeleteAsync(usuario);
    }

    public async Task<ICollection<ReadUserDto>> FindAll()
    {
        var users = await _signInManager.UserManager.Users.ToListAsync();

        var dtoUsers = _mapper.Map<ICollection<ReadUserDto>>(users);

        return dtoUsers;
    }

    public async Task<ReadUserDto> FindById(string id)
    {
        var user = await 
            _signInManager
            .UserManager
            .Users
            .FirstOrDefaultAsync(user => user.NormalizedUserName == id);

        if (user == null) throw new Exception("user not found");

        var dtoUser = _mapper.Map<ReadUserDto>(user);

        return dtoUser;
    }

    public async Task<string> Login(LoginUserDto loginUserType)
    {
        var result = await
            _signInManager
            .PasswordSignInAsync(
                loginUserType.Username,
                loginUserType.Password,
                false,
                false
                );

        throw new NotImplementedException();
    }

    public async Task<ReadUserDto> UpdateById(UpdateUserDto dto, string id)
    {
        throw new NotImplementedException();
    }
}