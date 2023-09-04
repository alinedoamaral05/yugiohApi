using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.Dtos.Response;

public class ReadDeckDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ReadUserDto User { get; set; }
}
