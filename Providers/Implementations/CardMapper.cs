using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class CardMapper : ICardMapper
{
    private readonly IMapper _mapper;

    public CardMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public CreateCardDto ToCreateDto(UpdateCardDto dto) =>
        _mapper.Map<CreateCardDto>(dto);


    public Card UpdateModel(UpdateCardDto dto, Card card) =>
        _mapper.Map(dto, card);


    public Card ToModel(CreateCardDto dto) =>
    _mapper.Map<Card>(dto);



    public ReadCardDto ToReadDto(Card card) =>
        _mapper.Map<ReadCardDto>(card);

    public ICollection<ReadCardDto> ToReadDtoCollection(ICollection<Card> cards) =>
        _mapper.Map<ICollection<ReadCardDto>>(cards);
}
