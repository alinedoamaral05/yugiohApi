using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.IServices;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Exceptions;

namespace YuGiOhApi.Services
{
    public class CardService : IService<ReadCardDto, CreateCardDto, UpdateCardDto, int>
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly IMapper _mapper;

        public CardService(IRepository<Card> cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<ReadCardDto> Create(CreateCardDto dto)
        {
            var card = _mapper.Map<Card>(dto);
            await _cardRepository.Create(card);

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }

        public async Task DeleteById(int id)
        {
            var card = await _cardRepository.FindById(id) ?? throw new NotFoundException();

            await _cardRepository.Delete(card);
        }

        public async Task<ICollection<ReadCardDto>> FindAll()
        {
            var cards = await _cardRepository.FindAll();
            var list = _mapper.Map<IList<ReadCardDto>>(cards);

            return list;
        }

        public async Task<ReadCardDto> FindById(int id)
        {
            var card = await _cardRepository.FindById(id) ?? throw new NotFoundException();

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }

        public async Task<ReadCardDto> UpdateById(UpdateCardDto dto, int id)
        {
            var card = await _cardRepository.FindById(id);
            if (card == null)
            {
                var create = _mapper.Map<CreateCardDto>(dto);
                return await Create(create);
            }

            _mapper.Map(dto, card);
            await _cardRepository.Update(card);

            var readDto = _mapper.Map<ReadCardDto>(card);

            return readDto;
        }
    }
}
