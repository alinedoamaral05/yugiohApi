using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Providers.Interfaces;

namespace YuGiOhApi.Providers.Implementations;

public class UserMapper : IUserMapper
{
    private readonly IMapper _mapper;

    public UserMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public CreateUserDto ToCreateDto(UpdateUserDto dto) 
        => _mapper.Map<CreateUserDto>(dto);


    public User ToModel(CreateUserDto dto)
        => _mapper.Map<User>(dto);

    public ReadUserDto ToReadDto(User user)
        => _mapper.Map<ReadUserDto>(user);

    public ICollection<ReadUserDto> ToReadDtoCollection(ICollection<User> users)
        => _mapper.Map<List<ReadUserDto>>(users);

    public User UpdateModel(UpdateUserDto dto, User user)
        => _mapper.Map(dto, user);
}
