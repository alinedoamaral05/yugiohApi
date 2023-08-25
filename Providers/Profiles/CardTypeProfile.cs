using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class CardTypeProfile: Profile
{
    public CardTypeProfile()
    {

        CreateMap<CreateCardTypeDto, Card>();
        CreateMap<Card, ReadCardTypeDto>();
    }
}
