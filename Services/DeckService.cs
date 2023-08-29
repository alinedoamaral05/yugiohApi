using Microsoft.EntityFrameworkCore.Metadata;
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
    private readonly IDeckMapper _mapper;

    public DeckService(IDeckRepository deckRepository, IUserRepository userRepository, IDeckMapper mapper)
    {
        _deckRepository = deckRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ReadDeckDto> Create(CreateDeckDto dto)
    {
        var deck = _mapper.ToModel(dto);

        var user = await _userRepository.FindById(dto.UserName);

        deck.User = user ?? throw new NotFoundException(name:"User");

        await _deckRepository.Create(deck);
      
        var readDto = _mapper.ToReadDto(deck);

        return readDto;
    }

    public async Task DeleteById(int id)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException(name:"Deck");

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
}
