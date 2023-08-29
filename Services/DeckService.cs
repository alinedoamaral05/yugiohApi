using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Exceptions;

namespace YuGiOhApi.Services;

public class DeckService : IService<ReadDeckDto, CreateDeckDto, UpdateDeckDto, int>
{
    private readonly IRepository<Deck> _deckRepository;
    private readonly IMapper _mapper;

    public DeckService(IRepository<Deck> deckRepository, IMapper mapper)
    {
        _deckRepository = deckRepository;
        _mapper = mapper;
    }

    public async Task<ReadDeckDto> Create(CreateDeckDto dto)
    {
        var deck = _mapper.Map<Deck>(dto);
        await _deckRepository.Create(deck);

        var readDto = _mapper.Map<ReadDeckDto>(deck);

        return readDto;
    }

    public async Task DeleteById(int id)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException();

        await _deckRepository.Delete(deck);
    }

    public async Task<ICollection<ReadDeckDto>> FindAll()
    {
        var decks = await _deckRepository.FindAll();
        var list = _mapper.Map<IList<ReadDeckDto>>(decks);

        return list;
    }

    public async Task<ReadDeckDto> FindById(int id)
    {
        var deck = await _deckRepository.FindById(id) ?? throw new NotFoundException();

        var readDto = _mapper.Map<ReadDeckDto>(deck);

        return readDto;
    }

    public async Task<ReadDeckDto> UpdateById(UpdateDeckDto dto, int id)
    {
        var deck = await _deckRepository.FindById(id);
        if (deck == null)
        {
            var create = _mapper.Map<CreateDeckDto>(dto);
            return await Create(create);
        }

        _mapper.Map(dto, deck);
        await _deckRepository.Update(deck);

        var readDto = _mapper.Map<ReadDeckDto>(deck);

        return readDto;
    }
}
