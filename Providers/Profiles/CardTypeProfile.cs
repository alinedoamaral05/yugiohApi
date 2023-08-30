using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class CardTypeProfile: Profile
{
    public CardTypeProfile()
    {
        CreateMap<CreateCardTypeDto, CardType>();
        CreateMap<CardType, ReadCardTypeDto>();
        CreateMap<UpdateCardTypeDto, CardType>();
        CreateMap<UpdateCardTypeDto, CreateCardTypeDto>();
    }
}
