using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class DeckMapper : IDeckMapper
{
    private readonly IMapper _mapper;
    public DeckMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public CreateDeckDto ToCreateDto(UpdateDeckDto dto) =>
        _mapper.Map<CreateDeckDto>(dto);


    public Deck UpdateModel(UpdateDeckDto dto, Deck deck) =>
        _mapper.Map(dto, deck);


    public Deck ToModel(CreateDeckDto dto) =>
    _mapper.Map<Deck>(dto);



    public ReadDeckDto ToReadDto(Deck deck) =>
        _mapper.Map<ReadDeckDto>(deck);

    public ICollection<ReadDeckDto> ToReadDtoCollection(ICollection<Deck> decks) =>
        _mapper.Map<ICollection<ReadDeckDto>>(decks);
}
