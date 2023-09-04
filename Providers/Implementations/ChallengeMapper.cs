using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class ChallengeMapper : IChallengeMapper<Challenge, CreateChallengeDto, ReadChallengeDto, ChoseDeckDto>
{
    private readonly IMapper _mapper;

    public ChallengeMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Challenge ChoseToModel(ChoseDeckDto choseDto) =>
        _mapper.Map<Challenge>(choseDto);

    public ReadChallengeDto ToReadChallengeDto(Challenge challenge) =>
        _mapper.Map<ReadChallengeDto>(challenge);

    public ICollection<ReadChallengeDto> ReadCollection(ICollection<Challenge> challenges) =>
        _mapper.Map<ICollection<ReadChallengeDto>>(challenges);

    public Challenge ToModel(CreateChallengeDto createDto) =>
        _mapper.Map<Challenge>(createDto);

    public Challenge UpdateModel(ChoseDeckDto dto, Challenge challenge) =>
        _mapper.Map(dto, challenge);
    
}
