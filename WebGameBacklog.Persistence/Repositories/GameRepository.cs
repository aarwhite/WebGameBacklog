using WebGameBacklog.Domain.Games;
using WebGameBacklog.Domain.Repositories;

namespace WebGameBacklog.Persistence.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {   
    }
}
