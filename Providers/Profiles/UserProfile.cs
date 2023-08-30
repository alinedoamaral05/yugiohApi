using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ReadUserDto>();
        CreateMap<LoginUserDto, User>();
        CreateMap<UpdateUserDto, CreateUserDto>();
    }
}