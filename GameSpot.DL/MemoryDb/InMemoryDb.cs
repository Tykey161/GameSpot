using GameSpot.Models;

namespace GameSpot.DL.MemoryDb
{
    public static class InMemoryDb
    {
        public static List<Game> GameData = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                Title = "Game 1",
                Genre = "Action",
                Description = "Description for Game 1",
                Price = 49.99m,
                PublisherId = 1 // Assuming publisher with Id = 1 exists in the database
            },
            new Game()
            {
                Id = 2,
                Title = "Game 2",
                Genre = "RPG",
                Description = "Description for Game 2",
                Price = 39.99m,
                PublisherId = 2 // Assuming publisher with Id = 2 exists in the database
            },
            new Game()
            {
                Id = 3,
                Title = "Game 3",
                Genre = "Adventure",
                Description = "Description for Game 3",
                Price = 59.99m,
                PublisherId = 1 // Assuming publisher with Id = 1 exists in the database
            }
        };

        public static List<Publisher> PublisherData = new List<Publisher>()
        {
            new Publisher()
            {
                Id = 1,
                Name = "Publisher 1",
                Headquarters = "Headquarters for Publisher 1",
                Website = "www.publisher1.com"
            },
            new Publisher()
            {
                Id = 2,
                Name = "Publisher 2",
                Headquarters = "Headquarters for Publisher 2",
                Website = "www.publisher2.com"
            },
            new Publisher()
            {
                Id = 3,
                Name = "Publisher 3",
                Headquarters = "Headquarters for Publisher 3",
                Website = "www.publisher3.com"
            }
        };
    }
}
