using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.Dtos.Response;

public class ReadCardDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CardTypeId { get; set; }
    public ReadCardTypeDto CardType { get; set; }
    public string Description { get; set; }
    public int AttackPoints { get; set; }
    public int? DeffensePoints { get; set; }
}
