using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGameBacklog.Domain;

namespace WebGameBacklog.Tests.Domain
{
    [TestClass]
    public class GameBacklogTests
    {
        [TestMethod]
        public void Create_WithValidName_ThenCreateGameBacklog()
        {
            var backlog = GameBacklog.Create("Aaron's Backlog");

            Assert.IsNotNull(backlog);
            Assert.AreEqual(backlog.Name, "Aaron's Backlog");
            Assert.AreEqual(backlog.Games.Count(), 0);
        }   
        
        [TestMethod]     
        public void AddGame_WithValidGame_ThenAddSuccessfully()
        {

        }

        [TestMethod]
        public void AddMultipleGames_WithValidGames_ThenAddAllSuccessfully()
        {

        }
    }
}
