using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGameBacklog.Domain;
using WebGameBacklog.Domain.Games;
using WebGameBacklog.Domain.Repositories;
using WebGameBacklog.Shared.Persistence;

namespace WebGameBacklog.Services.Games
{
    public class GameBacklogService : IGameBacklogService
    {
        private readonly IGameBacklogRepository _gameBacklogRepository;

        public GameBacklogService(IGameBacklogRepository gameBacklogRepository)
        {
            _gameBacklogRepository = gameBacklogRepository;
        }

        [UnitOfWork]
        public void AddGame(Guid id, CreateGameDto dto)
        {
            GameBacklog backlog = _gameBacklogRepository.Get(id);
            backlog.AddGame(dto);
        }

        [UnitOfWork]
        public void Create(string name)
        {
            GameBacklog backlog = GameBacklog.Create(name);
            _gameBacklogRepository.Add(backlog);
        }

        [UnitOfWork]
        public void DeleteGame(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public GameBacklogDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDto> GetAllForBacklog(Guid id)
        {
            throw new NotImplementedException();
        }

        public GameDto GetGame(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
