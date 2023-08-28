using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface ICardService
{
    Task<ReadCardDto> Create(CreateCardDto dto);
    Task<ReadCardDto> UpdateById(CreateCardDto dto, int id);
    Task DeleteById(int id);
    Task<ReadCardDto> FindById(int id);
    Task<ICollection<ReadCardDto>> FindAll();
}
