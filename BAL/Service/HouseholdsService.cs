
using BAL.Interfaces;
using DAL.Interface;

using System.Collections.Generic;
using System.Linq;


namespace BAL.Service
{
    public class HouseholdsService : IHouseholdsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HouseholdsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }


        public List<int> GetStatesActuals(int state)
        {
            if (_unitOfWork.ActualsRepository != null)
            {
                return _unitOfWork.ActualsRepository.GetStatesActuals(state);
            }
            else
            {
                return new List<int>();
            }
            
        }

        public List<int> GetStatesEstimates(int state)
        {
            if (_unitOfWork.EstimatesRepository != null)
            {
                return _unitOfWork.EstimatesRepository.GetStatesEstimates(state);
            }
            else
            {
                return new List<int>();
            }
            
        }

        public IEnumerable<dynamic> GetActualsHouseholdsDataByState(int state)
        {
            if (_unitOfWork.ActualsRepository != null)
            {
                return _unitOfWork.ActualsRepository.GetActualsHouseholdsDataByState(state);
            }
            else
            {
                return Enumerable.Empty<dynamic>();
            }
        }
        public IEnumerable<dynamic> GetEstimatesHouseholdsDataByState(int state)
        {
            if (_unitOfWork.EstimatesRepository != null)
            {
                return _unitOfWork.EstimatesRepository.GetEstimatesHouseholdsDataByState(state);
            }
            else
            {
                return Enumerable.Empty<dynamic>();
            }
        }
    }
}