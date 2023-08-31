using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface IUserService<LoginUserType> : IService<ReadUserDto, CreateUserDto, UpdateUserDto, string>
{
    Task<string> Login(LoginUserType loginUserType);
    Task<int> GetTotalUsers();
}
