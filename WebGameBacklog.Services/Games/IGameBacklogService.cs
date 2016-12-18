using System;
using System.Collections.Generic;
using WebGameBacklog.Domain.Games;

namespace WebGameBacklog.Services.Games
{
    public interface IGameBacklogService
    {
        void Create(string name);

        void AddGame(Guid id, CreateGameDto dto);

        GameBacklogDto Get(Guid id);

        GameDto GetGame(Guid gameId);

        void DeleteGame(Guid gameId);

        IEnumerable<GameDto> GetAllForBacklog(Guid id);
    }
}
