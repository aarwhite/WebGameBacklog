using WebGameBacklog.Domain.Games;
using FluentNHibernate.Mapping;

namespace WebGameBacklog.Persistence.Mappings
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Table("Game");

            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Not.Nullable();

            Map(x => x.DateAdded)
                .Not.Nullable();

            Map(x => x.Plateform)
                .Not.Nullable();

            Map(x => x.State)
                .Not.Nullable();
        }
    }
}
