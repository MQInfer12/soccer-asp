namespace asp_test.Models
{
  public class Tournament
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; } = "Copenhague";
    public List<Game> Games { get; set; } = new List<Game>();
  }
}