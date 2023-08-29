using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Interfaces;

public interface ICardTypeMapper : IGeneralMapper
    <CardType, CreateCardTypeDto, UpdateCardTypeDto, ReadCardTypeDto>
{
}
