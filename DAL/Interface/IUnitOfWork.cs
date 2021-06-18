

using DAL.Models;
using DAL.Repository;

namespace DAL.Interface
{
    public interface IUnitOfWork
    {
        public void Save();
        public Repository<Actuals> ActualsRepository { get; }
        public Repository<Estimates> EstimatesRepository { get; }

    }
}
