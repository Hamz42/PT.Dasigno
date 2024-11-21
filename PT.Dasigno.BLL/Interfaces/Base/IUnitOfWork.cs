using PT.Dasigno.DAL.Context.ContextDasigno;

namespace PT.Dasigno.BLL.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        dbContextDasigno ContextDasigno { get; }

        void Commit();
    }
}
