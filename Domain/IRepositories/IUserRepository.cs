using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface IUserRepository : IRepository<User, string>
{
    Task<int> GetTotalUsers();
}
