using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class CardTypeMapper : ICardTypeMapper
{
    private readonly IMapper _mapper;
    public CardTypeMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public CreateCardTypeDto ToCreateDto(UpdateCardTypeDto dto) =>
        _mapper.Map<CreateCardTypeDto>(dto);


    public CardType UpdateModel(UpdateCardTypeDto dto, CardType card) =>
        _mapper.Map(dto, card);


    public CardType ToModel(CreateCardTypeDto dto) =>
    _mapper.Map<CardType>(dto);



    public ReadCardTypeDto ToReadDto(CardType card) =>
        _mapper.Map<ReadCardTypeDto>(card);

    public ICollection<ReadCardTypeDto> ToReadDtoCollection(ICollection<CardType> cards) =>
        _mapper.Map<ICollection<ReadCardTypeDto>>(cards);
}
