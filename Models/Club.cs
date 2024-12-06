namespace asp_test.Models
{
  public class Club
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Shield { get; set; }
    public List<Banner> Banners1 { get; set; } = new List<Banner>();
    public List<Banner> Banners2 { get; set; } = new List<Banner>();
    public List<Game> Games1 { get; set; } = new List<Game>();
    public List<Game> Games2 { get; set; } = new List<Game>();
  }
}