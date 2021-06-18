using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IPopulationService
    {
        public List<int> GetStatesActuals(int state);
        public List<int> GetStatesEstimates(int state);
        public IEnumerable<dynamic> GetActualsPopulationDataByState(int state);
        public IEnumerable<dynamic> GetEstimatesPopulationDataByState(int state);
    }
}
