using DAL.Data;
using DAL.Models;
using DAL.Repository;
using System;
using DAL.Interface;

namespace AspNetCoreWebApiService2021.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly ApplicationDbContext _context;
        private Repository<Actuals> actualsRepository;
        private Repository<Estimates> estimatesRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Repository<Actuals> ActualsRepository
        {
            get
            {

                if (actualsRepository == null)
                {
                    actualsRepository = new Repository<Actuals>(_context);
                }
                return actualsRepository;
            }
        }

        public Repository<Estimates> EstimatesRepository
        {
            get
            {

                if (estimatesRepository == null)
                {
                    estimatesRepository = new Repository<Estimates>(_context);
                }
                return estimatesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {          
               _context.Dispose();
                
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
