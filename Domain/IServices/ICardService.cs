using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface ICardService
{
    ReadCardDto Create(CreateCardDto dto);
    ReadCardDto UpdateById(CreateCardDto dto, int id);
    void DeleteById(int id);
    ReadCardDto FindById(int id);
    ICollection<ReadCardDto> FindAll();
}
