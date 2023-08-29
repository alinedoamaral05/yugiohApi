using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Interfaces;

public interface ICardMapper : IGeneralMapper
    <Card, CreateCardDto, UpdateCardDto, ReadCardDto>
{
}
