using GameSpot.BL.Interfaces;
using GameSpot.BL.Services;

using GameSpot.Models.Request;
using GameSpot.Models;

using Moq;

namespace GameSpot.Tests
{
    public class GameSpotStoreTest
    {
        public static List<Game> GameData = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                Title = "Game 1",
                Genre = "Action",
                Description = "Description for Game 1",
                Price = 29.99m,
                PublisherId = 1
            },
            new Game()
            {
                Id = 2,
                Title = "Game 2",
                Genre = "Adventure",
                Description = "Description for Game 2",
                Price = 39.99m,
                PublisherId = 2
            }
        };

        public static List<Publisher> PublisherData = new List<Publisher>()
        {
            new Publisher()
            {
                Id = 1,
                Name = "Publisher 1",
                Headquarters = "Headquarters 1",
                Website = "www.publisher1.com"
            },
            new Publisher()
            {
                Id = 2,
                Name = "Publisher 2",
                Headquarters = "Headquarters 2",
                Website = "www.publisher2.com"
            }
        };

        [Fact]
        public void AddGameWithPublisher_ValidRequest()
        {
            var request = new AddGameWithPublisherRequest
            {
                Game = new Game
                {
                    Title = "New Game",
                    Genre = "Action",
                    Description = "Description for New Game",
                    Price = 49.99m,
                    PublisherId = 3 // Assuming this publisher doesn't exist yet
                },
                Publisher = new Publisher
                {
                    Name = "New Publisher",
                    Headquarters = "New Headquarters",
                    Website = "www.newpublisher.com"
                }
            };

            var mockedGameService = new Mock<IGameService>();
            mockedGameService.Setup(x => x.Add(It.IsAny<Game>()));

            var mockedPublisherService = new Mock<IPublisherService>();
            mockedPublisherService.Setup(x => x.Add(It.IsAny<Publisher>()));

            var service = new GameSpotStoreService(mockedGameService.Object, mockedPublisherService.Object);
            service.AddGameWithPublisher(request);

            mockedGameService.Verify(x => x.Add(It.IsAny<Game>()), Times.Once);
            mockedPublisherService.Verify(x => x.Add(It.IsAny<Publisher>()), Times.Once);
        }

        [Fact]
        public void GetGamesPublishedBy_ValidRequest()
        {
            var request = new GetGamesPublishedByRequest
            {
                PublisherName = "Publisher 1"
            };

            var expectedGames = GameData.Where(g => g.PublisherId == 1).ToList();

            var mockedGameService = new Mock<IGameService>();
            mockedGameService.Setup(x => x.GetAll()).Returns(GameData);

            var mockedPublisherService = new Mock<IPublisherService>();
            mockedPublisherService.Setup(x => x.GetAll()).Returns(PublisherData);

            var service = new GameSpotStoreService(mockedGameService.Object, mockedPublisherService.Object);

            var response = service.GetGamesPublishedBy(request);

            Assert.NotNull(response);
            Assert.Equal(expectedGames, response.Games);
        }
    }
}