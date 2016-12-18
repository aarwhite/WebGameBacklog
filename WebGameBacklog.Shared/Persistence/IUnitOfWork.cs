using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGameBacklog.Shared.Persistence
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
