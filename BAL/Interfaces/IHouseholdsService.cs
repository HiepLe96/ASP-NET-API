using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IHouseholdsService
    {
        public List<int> GetStatesActuals(int state);
        public List<int> GetStatesEstimates(int state);
        public IEnumerable<dynamic> GetActualsHouseholdsDataByState(int state);
        public IEnumerable<dynamic> GetEstimatesHouseholdsDataByState(int state);


    }
}
