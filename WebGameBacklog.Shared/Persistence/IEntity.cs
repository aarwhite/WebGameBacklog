using System;

namespace WebGameBacklog.Shared.Persistence
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
