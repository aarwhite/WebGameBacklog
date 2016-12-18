using System;
using System.Collections.Generic;
using System.Linq;
using WebGameBacklog.Domain.Games;

namespace WebGameBacklog.Domain
{
    public class GameBacklog
    {
        private ISet<Game> _games = new HashSet<Game>();

        private GameBacklog(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public IEnumerable<Game> Games
        {
            get
            {
                return _games;
            }
        }

        public decimal Completed
        {
            get
            {
                return _games.Where(x => x.State == GameState.Completed).Count();
            }
        }

        public decimal NotStarted
        {
            get
            {
                return _games.Where(x => x.State == GameState.NotStarted).Count();
            }
        }

        public decimal InProgress
        {
            get
            {
                return _games.Where(x => x.State == GameState.InProgress).Count();
            }
        }

        public void AddGame(CreateGameDto createGameDto)
        {
            Game game = Game.Create(createGameDto);
            _games.Add(game);
        }

        public Game GetGame(Guid gameId)
        {
            return _games.FirstOrDefault(x => x.Id == gameId);
        }

        public static GameBacklog Create(string name)
        {
            return new GameBacklog(name);
        }
    }
}
