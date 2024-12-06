namespace asp_test.Models
{
  public class Game
  {
    public int Id { get; set; }
    public required int TournamentId { get; set; }
    public required int Club1Id { get; set; }
    public required int Club2Id { get; set; }
    public required DateOnly Date { get; set; }
    public int? WinnerId { get; set; }
    public Tournament Tournament { get; set; } = null!;
    public Club Club1 { get; set; } = null!;
    public Club Club2 { get; set; } = null!;
  }
}