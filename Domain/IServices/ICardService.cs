using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface ICardService : IService<ReadCardDto, CreateCardDto, UpdateCardDto, int>
{
    public Task<ICollection<ReadCardDto>> FindByName(string name);
}
