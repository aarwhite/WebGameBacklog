using WebGameBacklog.Domain;
using WebGameBacklog.Domain.Repositories;
using WebGameBacklog.Shared.Persistence;

namespace WebGameBacklog.Persistence.Repositories
{
    public class GameBacklogRepository : Repository<GameBacklog>, IGameBacklogRepository
    {   
    }
}
