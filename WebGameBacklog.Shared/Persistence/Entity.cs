using System;

namespace WebGameBacklog.Shared.Persistence
{
    public class Entity : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}
