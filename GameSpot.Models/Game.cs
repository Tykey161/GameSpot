namespace GameSpot.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
