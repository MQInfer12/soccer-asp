namespace asp_test.Models
{
  public class Player
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Position { get; set; }
    public required int Number { get; set; }
    public required DateOnly Date { get; set; }
  }
}