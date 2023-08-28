using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface IService<ReadType, CreateType, UpdateType, Type>
{
    Task<ReadType> Create(CreateType dto);
    Task<ReadType> UpdateById(UpdateType dto, Type id);
    Task DeleteById(Type id);
    Task<ReadType> FindById(Type id);
    Task<ICollection<ReadType>> FindAll();
}
