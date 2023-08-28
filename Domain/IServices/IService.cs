using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface IService<ReadType, CreateType, UpdateType>
{
    Task<ReadType> Create(CreateType dto);
    Task<ReadType> UpdateById(UpdateType dto, int id);
    Task DeleteById(int id);
    Task<ReadType> FindById(int id);
    Task<ICollection<ReadType>> FindAll();
}
