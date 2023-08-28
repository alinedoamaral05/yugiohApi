namespace YuGiOhApi.Domain.Dtos.Request
{
    public class UpdateCardDto
    {   
        public string Name { get; set; }
        public int CardTypeId { get; set; }
        public string Description { get; set; }
        public int AttackPoints { get; set; }
        public int? DeffensePoints { get; set; }
    }
}
