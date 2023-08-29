using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Exceptions;
using YuGiOhApi.Infra.Database.Repositories;

namespace YuGiOhApi.Services;

public class CardTypeService : ICardTypeService
{
    private readonly IRepository<CardType> _cardTypeRepository;
    private readonly IMapper _mapper;

    public CardTypeService(IRepository<CardType> cardTypeRepository, IMapper mapper)
    {
        _cardTypeRepository = cardTypeRepository;
        _mapper = mapper;
    }

    public async Task<ReadCardTypeDto> Create(CreateCardTypeDto dto)
    {
        var cardType = _mapper.Map<CardType>(dto);
        await _cardTypeRepository.Create(cardType);

        var readDto = _mapper.Map<ReadCardTypeDto>(cardType);

        return readDto;
    }

    public async Task DeleteById(int id)
    {
        var card = await _cardTypeRepository.FindById(id) ?? throw new NotFoundException();

        await _cardTypeRepository.Delete(card);
    }

    public async Task<ICollection<ReadCardTypeDto>> FindAll()
    {
        var cardsType = await _cardTypeRepository.FindAll();
        var list = _mapper.Map<IList<ReadCardTypeDto>>(cardsType);

        return list;
    }

    public async Task<ReadCardTypeDto> FindById(int id)
    {
        var cardType = await _cardTypeRepository.FindById(id) ?? throw new NotFoundException();

        var readDto = _mapper.Map<ReadCardTypeDto>(cardType);

        return readDto;
    }

    public async Task<ReadCardTypeDto> UpdateById(UpdateCardTypeDto dto, int id)
    {
        var card = await _cardTypeRepository.FindById(id);
        if (card == null)
        {
            var create = _mapper.Map<CreateCardTypeDto>(dto);
            return await Create(create);
        }

        _mapper.Map(dto, card);
        await _cardTypeRepository.Update(card);

        var readDto = _mapper.Map<ReadCardTypeDto>(card);

        return readDto;
    }
}
