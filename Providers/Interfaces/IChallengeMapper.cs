using System.Runtime.CompilerServices;

namespace YuGiOhApi.Providers.Interfaces;

public interface IChallengeMapper<Challenge, CreateChallengeDto, ReadChallengeDto, ChoseDeckDto>
{
    public Challenge ToModel(CreateChallengeDto createDto);

    public ReadChallengeDto ToReadChallengeDto(Challenge challenge);

    public Challenge ChoseToModel(ChoseDeckDto choseDto);

    public Challenge UpdateModel(ChoseDeckDto dto,  Challenge challenge);

    public ICollection<ReadChallengeDto> ReadCollection(ICollection<Challenge> challenges);
}
