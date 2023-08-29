using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Exceptions;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Services;

public class CardTypeService : ICardTypeService
{
    private readonly ICardTypeRepository _cardTypeRepository;
    private readonly ICardTypeMapper _mapper;

    public CardTypeService(ICardTypeRepository cardTypeRepository, ICardTypeMapper mapper)
    {
        _cardTypeRepository = cardTypeRepository;
        _mapper = mapper;
    }

    public async Task<ReadCardTypeDto> Create(CreateCardTypeDto dto)
    {
        var cardType = _mapper.ToModel(dto);
        await _cardTypeRepository.Create(cardType);

        var readDto = _mapper.ToReadDto(cardType);

        return readDto;
    }

    public async Task DeleteById(int id)
    {
        var cardType = await _cardTypeRepository.FindById(id) ?? throw new NotFoundException(name:"Card type");

        await _cardTypeRepository.Delete(cardType);
    }

    public async Task<ICollection<ReadCardTypeDto>> FindAll()
    {
        var cardsType = await _cardTypeRepository.FindAll();
        var list = _mapper.ToReadDtoCollection(cardsType);

        return list;
    }

    public async Task<ReadCardTypeDto> FindById(int id)
    {
        var cardType = await _cardTypeRepository.FindById(id) ?? throw new NotFoundException(name: "Card type");

        var readDto = _mapper.ToReadDto(cardType);

        return readDto;
    }

    public async Task<ReadCardTypeDto> UpdateById(UpdateCardTypeDto dto, int id)
    {
        var cardType = await _cardTypeRepository.FindById(id);
        if (cardType == null)
        {
            var create = _mapper.ToCreateDto(dto);
            return await Create(create);
        }

        _mapper.UpdateModel(dto, cardType);
        await _cardTypeRepository.Update(cardType);

        var readDto = _mapper.ToReadDto(cardType);

        return readDto;
    }
}
