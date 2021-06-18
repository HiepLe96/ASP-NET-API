using DAL.Data;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        readonly ApplicationDbContext _dbContext;
 
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
    
        }
    
     
        public virtual List<int> GetStatesActuals(int state)
        {
            return _dbContext.Actuals.Where(a => a.State == state).Select(a => a.State).ToList();
        }

        public virtual List<int> GetStatesEstimates(int state)
        {
            return _dbContext.Estimates.Where(a => a.State == state).Select(a => a.State).ToList();
        }

        public IEnumerable<dynamic> GetActualsPopulationDataByState(int state)
        {
            return _dbContext.Actuals
                            .Where(a => a.State == state)
                            .Select(a => new {
                                State = state,
                                a.ActualPopulation
                            }).AsEnumerable().Distinct();
        }

        public IEnumerable<dynamic> GetEstimatesPopulationDataByState(int state)
        {
            return _dbContext.Estimates
                        .GroupBy(e => state)
                        .Select(e => new {
                            State = state,
                            EstimatesPopulation = e.Sum(x => x.EstimatesPopulation)
                        }).AsEnumerable().Distinct();
        }
        public virtual IEnumerable<dynamic> GetActualsHouseholdsDataByState(int state)
        {
            return _dbContext.Actuals
                            .Where(a => a.State == state)
                            .Select(a => new {
                                State = state,
                               a.ActualHouseholds
                            }).AsEnumerable().Distinct();
        }

        public IEnumerable<dynamic> GetEstimatesHouseholdsDataByState(int state)
        {
            return _dbContext.Estimates
                        .GroupBy(e => state)
                        .Select(e => new {
                            State = state,
                            EstimatesHouseholds = e.Sum(x => x.EstimatesHouseholds)
                        }).AsEnumerable().Distinct();
        }

    }
}
