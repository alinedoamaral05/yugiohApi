using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;

namespace YuGiOhApi.Domain.IServices;

public interface ICardTypeService : IService<ReadCardTypeDto, CreateCardTypeDto, UpdateCardTypeDto, int>
{
}
