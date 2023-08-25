﻿namespace YuGiOhApi.Domain.Models;

public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CardTypeId { get; set; }
    public CardType CardType { get; set; }
    public string Description { get; set; }
    public int AttackPoints { get; set; }
    public int? DeffensePoints { get; set; }
}
