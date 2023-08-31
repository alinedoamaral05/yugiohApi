using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class ChallengeProfile : Profile
{
    public ChallengeProfile()
    {
        CreateMap<CreateChallengeDto, Challenge>();
        CreateMap<Challenge, ReadChallengeDto>();
        CreateMap<ChoseDeckDto, Challenge>();
    }
}
