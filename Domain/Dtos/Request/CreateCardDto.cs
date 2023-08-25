namespace YuGiOhApi.Domain.Dtos.Request;

public class CreateCardDto
{
    public string Name { get; set; }
    public int CardTypeId { get; set; }
    public string Description { get; set; }
    public int AttackPoints { get; set; }
    public int? DeffensePoints { get; set; }
}
/*
 nome, tipo (monstro, magia, armadilha), descrição, pontos de ataque e pontos de defesa (se aplicável).
 */