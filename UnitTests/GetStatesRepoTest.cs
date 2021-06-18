

using DAL.Interface;
using DAL.Models;

using Moq;

using System.Collections.Generic;

using Xunit;

namespace UnitTests
{
    public class GetStatesRepoTest
    {

        private readonly Mock<IRepository<Actuals>> _mockActualsRepo;
        private readonly Mock<IRepository<Estimates>> _mockEstimatesRepo;

        public GetStatesRepoTest()
        {
            _mockActualsRepo = new Mock<IRepository<Actuals>>();
            _mockEstimatesRepo = new Mock<IRepository<Estimates>>();


        }


        [Fact]
        public List<int> GetStatesActuals()
        {
            _mockActualsRepo.Setup(p => p.GetStatesActuals(1)).Returns(new List<int> { 1});

            var result = _mockActualsRepo.Object.GetStatesActuals(1);

            // assert phase
            Assert.NotNull(result);
            Assert.Equal("True", result.Contains(1).ToString());          
            return result;
        }

        [Fact]
        public List<int> GetStatesEstimates()
        {
            _mockEstimatesRepo.Setup(p => p.GetStatesEstimates(1)).Returns(new List<int> { 1 });

            var result = _mockEstimatesRepo.Object.GetStatesEstimates(1);

            // assert phase
            Assert.NotNull(result);
            Assert.Equal("True", result.Contains(1).ToString());       
            return result;
        }

    }
}
