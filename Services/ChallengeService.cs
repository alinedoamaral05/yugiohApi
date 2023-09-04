using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Exceptions;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Services;

public class ChallengeService : IChallengeService<CreateChallengeDto, ReadChallengeDto, ChoseDeckDto>
{
    private SignInManager<User> _signInManager;
    private readonly IChallengeMapper<Challenge, CreateChallengeDto, ReadChallengeDto, ChoseDeckDto> _mapper;
    private readonly IChallengerRepository _chRepository;
    public ChallengeService(SignInManager<User> signInManager, IChallengeMapper<Challenge, CreateChallengeDto, ReadChallengeDto, ChoseDeckDto> mapper, IChallengerRepository chRepository)
    {
        _signInManager = signInManager;
        _mapper = mapper;
        _chRepository = chRepository;
    }
    public async Task<Challenge> Accept(int id)
    {
        var duel = await _chRepository.FindById(id);

        if (duel is null)
            throw new NotFoundException(name: "Duel");

        duel.Status = true;

        await _chRepository.Update(duel);

        return duel;
    }

    public async Task<ReadChallengeDto> Create(CreateChallengeDto createChallengeDto)
    {
        var challenger = await _signInManager.UserManager.Users.FirstOrDefaultAsync(user => user.UserName == createChallengeDto.ChallengerUsername);
        var opponent = await _signInManager.UserManager.Users.FirstOrDefaultAsync(user => user.UserName == createChallengeDto.OpponentUsername);

        if (challenger is null || opponent is null)
            throw new NotFoundException(name: "User");

        var challenge = _mapper.ToModel(createChallengeDto);
        await _chRepository.Create(challenge);

        var challengeDto = _mapper.ToReadChallengeDto(challenge);
        return challengeDto;
    }

    public async Task<Challenge> Decline(int duelId)
    {
        var duel = await _chRepository.FindById(duelId);

        if (duel is null)
            throw new NotFoundException(name: "Duel");

        await _chRepository.Delete(duel);

        return duel;
    }

    public async Task<ReadChallengeDto> SelectDeck(int duelId, ChoseDeckDto choseDeck)
    {
        var duel = await _chRepository.FindById(duelId);

        if (duel is null)
            throw new NotFoundException(name: "Duel");

        var challenger = await _signInManager.UserManager.Users.Include(user => user.Decks).FirstOrDefaultAsync(user => user.UserName == duel.ChallengerUsername);

        if (challenger is null)
            throw new NotFoundException(name: "User");

        var opponent = await _signInManager.UserManager.Users.Include(user => user.Decks).FirstOrDefaultAsync(user => user.UserName == duel.OpponentUsername);

        if (opponent is null)
            throw new NotFoundException(name: "User");

        if (duel.Status is false)
            throw new InvalidOperationException("O duelo não foi aceito.");

        var challengerDeck = challenger.Decks.FirstOrDefault(d => d.Id == choseDeck.ChosenChallengerDeckId);
        var opponentDeck = opponent.Decks.FirstOrDefault(d => d.Id == choseDeck.ChosenOpponentDeckId);


        _mapper.UpdateModel(choseDeck, duel);

        if (challengerDeck is null || opponentDeck is null)
        {
            throw new NotFoundException(name: "Deck");
        }

        await _chRepository.Update(duel);

        var readChallengeDto = _mapper.ToReadChallengeDto(duel);

        return readChallengeDto;
    }

    public async Task<ICollection<ReadChallengeDto>> FindAll()
    {
        var challenges = await _chRepository.FindAll();

        var list = _mapper.ReadCollection(challenges);

        return list;
    }

    public async Task<ReadChallengeDto> FindById(int id)
    {
        var challenge = await _chRepository.FindById(id);

        var challengeDto = _mapper.ToReadChallengeDto(challenge);

        return challengeDto;
    }
}
