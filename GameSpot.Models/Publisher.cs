namespace GameSpot.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public string Website { get; set; }
        public List<Game> Games { get; set; }
    }
}
