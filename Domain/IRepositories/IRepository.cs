using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface IRepository<Type, FindBy>
{
    Task<Type> Create(Type type);
    Task<Type> Update(Type type);
    Task Delete(Type type);
    Task<Type?> FindById(FindBy id);
    Task<ICollection<Type>> FindAll();

}
