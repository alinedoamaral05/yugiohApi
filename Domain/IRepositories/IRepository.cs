using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface IRepository<Type>
{
    Task<Type> Create(Type type);
    Task<Type> Update(Type type);
    Task Delete(Type type);
    Task<Type?> FindById(int id);
    Task<ICollection<Type>> FindAll();
}
