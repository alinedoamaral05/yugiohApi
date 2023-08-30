using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface IDeckService : IService<ReadDeckDto, CreateDeckDto, UpdateDeckDto, int>
{
    public Task<ReadDeckDto> AddCardsToDeck(int id, List<int> cardIds);
}
