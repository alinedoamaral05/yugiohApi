namespace YuGiOhApi.Providers.Interfaces;

public interface IGeneralMapper
    <Type, CreateDto, UpdateDto, ReadDto>
{
    public Type ToModel(CreateDto dto);

    public Type UpdateModel(UpdateDto dto, Type type);

    public CreateDto ToCreateDto(UpdateDto dto);

    public ReadDto ToReadDto(Type type);

    public ICollection<ReadDto> ToReadDtoCollection(ICollection<Type> types);
}
