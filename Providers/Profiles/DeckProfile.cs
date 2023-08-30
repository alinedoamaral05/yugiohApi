using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class DeckProfile : Profile
{
    public DeckProfile()
    {
        CreateMap<CreateDeckDto, Deck>();
        CreateMap<UpdateDeckDto, Deck>();
        CreateMap<Deck, ReadDeckDto>();
        CreateMap<UpdateDeckDto, CreateDeckDto>();
    }       
}
