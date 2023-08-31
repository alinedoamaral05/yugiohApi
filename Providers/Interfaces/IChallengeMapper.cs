namespace YuGiOhApi.Providers.Interfaces;

public interface IChallengeMapper<Challenge, CreateChallengeDto, ReadChallengeDto, ChoseDeckDto>
{
    public Challenge ToModel(CreateChallengeDto createDto);

    public ReadChallengeDto ReadChallenge(Challenge challenge);

    public Challenge ChoseToModel(ChoseDeckDto choseDto);
}
