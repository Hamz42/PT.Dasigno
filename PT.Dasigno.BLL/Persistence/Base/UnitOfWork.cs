using PT.Dasigno.BLL.Interfaces.Base;
using PT.Dasigno.DAL.Context.ContextDasigno;

namespace PT.Dasigno.BLL.Persistence.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public dbContextDasigno ContextDasigno { get; }

        public UnitOfWork(dbContextDasigno contextDasigno)
        {
            ContextDasigno = contextDasigno;
        }

        public void Commit()
        {
            ContextDasigno.SaveChangesAsync();
        }

        public void Dispose()
        {
            ContextDasigno.Dispose();
        }
    }
}
