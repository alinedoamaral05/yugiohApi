using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Exceptions;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICardMapper _mapper;

        public CardService(ICardRepository cardRepository, ICardMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<ReadCardDto> Create(CreateCardDto dto)
        {
            var card = _mapper.ToModel(dto);
            await _cardRepository.Create(card);

            var readDto = _mapper.ToReadDto(card);

            return readDto;
        }

        public async Task DeleteById(int id)
        {
            var card = await _cardRepository.FindById(id) ?? throw new NotFoundException(name:"Card");

            await _cardRepository.Delete(card);
        }

        public async Task<ICollection<ReadCardDto>> FindAll()
        {
            var cards = await _cardRepository.FindAll();
            var list = _mapper.ToReadDtoCollection(cards);

            return list;
        }

        public async Task<ReadCardDto> FindById(int id)
        {
            var card = await _cardRepository.FindById(id) ?? throw new NotFoundException(name: "Card");

            var readDto = _mapper.ToReadDto(card);

            return readDto;
        }

        public async Task<ReadCardDto> UpdateById(UpdateCardDto dto, int id)
        {
            var card = await _cardRepository.FindById(id);
            if (card == null)
            {
                var create = _mapper.ToCreateDto(dto);
                return await Create(create);
            }

            _mapper.UpdateModel(dto, card);
            await _cardRepository.Update(card);

            var readDto = _mapper.ToReadDto(card);

            return readDto;
        }
    }
}
