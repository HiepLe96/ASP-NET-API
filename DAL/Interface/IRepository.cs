
using System.Collections.Generic;


namespace DAL.Interface
{
    public interface IRepository<T>
    {

       
        public List<int> GetStatesActuals(int state);
        public List<int> GetStatesEstimates(int state);
        public IEnumerable<dynamic> GetActualsPopulationDataByState(int state);
        public IEnumerable<dynamic> GetEstimatesPopulationDataByState(int state);
        public IEnumerable<dynamic> GetActualsHouseholdsDataByState(int state);
        public IEnumerable<dynamic> GetEstimatesHouseholdsDataByState(int state);

    }
}