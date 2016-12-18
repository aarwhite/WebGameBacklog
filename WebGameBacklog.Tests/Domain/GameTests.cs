using WebGameBacklog.Domain.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGameBacklog.Tests.Domain
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Create_WithMandatoryFields_ReturnGame()
        {
            const string GameName = "Uncharted4";
            DateTime dateAdded = new DateTime(2016, 10, 15);
            const string TimeToComplete = "15";

            CreateGameDto dto = new CreateGameDto
            {
                Name = GameName,
                Plateform = Platform.PS4,
                DateAdded = dateAdded,
                TimeToComplete = TimeToComplete
            };

            var game = Game.Create(dto);

            Assert.IsNotNull(game);
            Assert.AreEqual(game.State, GameState.NotStarted);
            Assert.AreEqual(game.Plateform, Platform.PS4);
            Assert.AreEqual(game.Name, GameName);
            Assert.AreEqual(game.DateAdded, dateAdded);
            Assert.AreEqual(game.TimeToComplete, TimeToComplete);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WhenDtoIsNull_ThrowException()
        {
            var game = Game.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WhenNameMissing_ThrowException()
        {
            DateTime dateAdded = new DateTime(2016, 10, 15);
            const string TimeToComplete = "15";

            CreateGameDto dto = new CreateGameDto
            {
                Name = null,
                Plateform = Platform.PS4,
                DateAdded = dateAdded,
                TimeToComplete = TimeToComplete
            };

            var game = Game.Create(dto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WhenPlatformMissing_ThrowException()
        {
            const string GameName = "Uncharted4";
            DateTime dateAdded = new DateTime(2016, 10, 15);
            const string TimeToComplete = "15";

            CreateGameDto dto = new CreateGameDto
            {
                Name = GameName,
                DateAdded = dateAdded,
                TimeToComplete = TimeToComplete
            };

            var game = Game.Create(dto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WhenDateAddedBefore2016_ThrowException()
        {
            const string GameName = "Uncharted4";
            const string TimeToComplete = "15";

            CreateGameDto dto = new CreateGameDto
            {
                Name = GameName,
                Plateform = Platform.PS4,
                TimeToComplete = TimeToComplete,
                DateAdded = new DateTime(2015, 01, 01)
            };

            var game = Game.Create(dto);
        }
    }
}
