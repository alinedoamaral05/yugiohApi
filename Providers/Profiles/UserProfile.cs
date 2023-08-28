using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;

namespace YuGiOhApi.Providers.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
