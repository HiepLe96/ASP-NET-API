
using BAL.Interfaces;
using DAL.Interface;
using System.Collections.Generic;
using System.Linq;


namespace BAL.Service
{
    public class PopulationService : IPopulationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PopulationService(IUnitOfWork unitOfWork)
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

        public IEnumerable<dynamic> GetActualsPopulationDataByState(int state)
        {
            if (_unitOfWork.ActualsRepository != null)
            {
                return _unitOfWork.ActualsRepository.GetActualsPopulationDataByState(state);
            }
            else
            {
                return Enumerable.Empty<dynamic>();
            }
        }
        public IEnumerable<dynamic> GetEstimatesPopulationDataByState(int state)
        {
            if (_unitOfWork.EstimatesRepository != null)
            {
                return _unitOfWork.EstimatesRepository.GetEstimatesPopulationDataByState(state);
            }
            else
            {
                return Enumerable.Empty<dynamic>();
            }
        }
     
    }
}