using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IServices;

public interface IChallengeService<CreateChallengeDto, ReadChallengeDto, ChoseDeckDto>
{
    public Task<ReadChallengeDto> Create(CreateChallengeDto createChallengeDto);

    public Task<Challenge> Accept(int duelId);

    public Task<Challenge> Decline(int duelId);

    public Task<ReadChallengeDto> SelectDeck(int duelId, ChoseDeckDto choseDeck);

}
