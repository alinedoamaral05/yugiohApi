using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Exceptions;

namespace YuGiOhApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public ReadCardDto Create(CreateCardDto dto)
        {
            var card = _mapper.Map<Card>(dto);
            _cardRepository.Create(card);

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }

        public void DeleteById(int id)
        {
            var card = _cardRepository.FindById(id) ?? throw new NotFoundException();

            _cardRepository.Delete(card);
        }

        public ICollection<ReadCardDto> FindAll()
        {
            var cards = _cardRepository.FindAll();
            var list = _mapper.Map<IList<ReadCardDto>>(cards);

            return list;
        }

        public ReadCardDto FindById(int id)
        {
            var card = _cardRepository.FindById(id) ?? throw new NotFoundException();

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }

        public ReadCardDto UpdateById(CreateCardDto dto, int id)
        {
            var card = _cardRepository.FindById(id);
            if (card == null)
            {
                return Create(dto);
            }

            _mapper.Map(dto, card);
            _cardRepository.Update(card);

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }
    }
}
