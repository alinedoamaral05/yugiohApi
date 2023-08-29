using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class CardTypeMapper : ICardTypeMapper
{
    private readonly ICardTypeMapper _mapper;
    public CardTypeMapper(ICardTypeMapper mapper)
    {
        _mapper = mapper;
    }

    public CreateCardTypeDto ToCreateDto(UpdateCardTypeDto dto) =>
        _mapper.Map<CreateCardTypeDto>(dto);


    public Card UpdateModel(UpdateCardTypeDto dto, Card card) =>
        _mapper.Map(dto, card);


    public Card ToModel(CreateCardDto dto) =>
    _mapper.Map<Card>(dto);



    public ReadCardDto ToReadDto(Card card) =>
        _mapper.Map<ReadCardDto>(card);

    public ICollection<ReadCardDto> ToReadDtoCollection(ICollection<Card> cards) =>
        _mapper.Map<ICollection<ReadCardDto>>(cards);
}
