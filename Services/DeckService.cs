using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Exceptions;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Services;

public class DeckService : IDeckService
{
    private readonly IDeckRepository _deckRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IDeckMapper _mapper;

    public DeckService(IDeckRepository deckRepository,
        IUserRepository userRepository,
        ICardRepository cardRepository,
        IDeckMapper mapper)
    {
        _deckRepository = deckRepository;
        _userRepository = userRepository;
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<ReadDeckDto> Create(CreateDeckDto dto)
    {
        var deck = _mapper.ToModel(dto);

        var user = await _userRepository.FindById(dto.UserName);

        deck.User = user ?? throw new NotFoundException(name: "User");

        var deckExists = user.Decks.Any(d => d.Name.ToLower() == deck.Name.ToLower());

        if (deckExists) throw new BadHttpRequestException("Deck name already exists");

        await _deckRepository.Create(deck);

        var readDto = _mapper.ToReadDto(deck);

        return readDto;
    }

    public async Task DeleteById(int id)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException(name: "Deck");

        await _deckRepository.Delete(deck);
    }

    public async Task<ICollection<ReadDeckDto>> FindAll()
    {
        var decks = await _deckRepository.FindAll();
        var list = _mapper.ToReadDtoCollection(decks);

        return list;
    }

    public async Task<ReadDeckDto> FindById(int id)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException(name: "Deck");

        var readDto = _mapper.ToReadDto(deck);

        return readDto;
    }

    public async Task<ReadDeckDto> UpdateById(UpdateDeckDto dto, int id)
    {
        var deck = await _deckRepository.FindById(id);
        if (deck == null)
        {
            var create = _mapper.ToCreateDto(dto);
            return await Create(create);
        }

        _mapper.UpdateModel(dto, deck);
        await _deckRepository.Update(deck);

        var readDto = _mapper.ToReadDto(deck);

        return readDto;
    }

    public async Task<ReadDeckDto> AddCardsToDeck(int id, List<int> cardIds)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException(name: "Deck");

        int maxLenghtDeck = 40;
        int cardIdsCount = cardIds.Count;
        int deckCount = deck.Cards.Count;

        if ((deckCount + cardIdsCount) > maxLenghtDeck) 
            throw new BadHttpRequestException("You can't add more than 40 cards to a deck");

        var cards = await _cardRepository.FindCardsById(cardIds);

        var deckList = deck.Cards.ToList();

        deckList.AddRange(cards);

        deck.Cards = deckList;

        deck = await _deckRepository.Update(deck);

        var deckDto = _mapper.ToReadDto(deck);

        return deckDto;
    }
}