namespace YuGiOhApi.Domain.Dtos.Response
{
    public class ReadChallengeDto
    {
        public int Id { get; set; }
        public string ChallengerUsername { get; set; }
        public string OpponentUsername { get; set; }
        public int ChosenChallengerDeckId { get; set; }
        public int ChosenOpponentDeckId { get; set; }
    }
}
