using System.Collections.Generic;
using ColleyMatrix.Provider;
using ColleyMatrix.Service;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ColleyMatrix.Tests.Service
{
    [TestFixture]
    public class ColleyMatrixServiceTests
    {   
        [Test]
        public void Should_SimluateGame_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            int winnerId = 0;
            int loserId = 1;
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = A.Fake<IValidatorService>();
            A.CallTo(() => matrixProvider.GetDimensions()).Returns(dimensions);
            IColleyMatrixService colleyMatrixService = new ColleyMatrixService(matrixProvider, validatorService);
            
            //act
            colleyMatrixService.SimulateGame(winnerId, loserId);

            //assert
            A.CallTo(() => validatorService.ValidateTeam(winnerId)).MustHaveHappened();
            A.CallTo(() => validatorService.ValidateTeam(loserId)).MustHaveHappened();
        }

        [Test]
        public void Should_ComputeRating_ForStandardInput()
        {
            //arrange
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = A.Fake<IValidatorService>();
            IColleyMatrixService colleyMatrixService = new ColleyMatrixService(matrixProvider, validatorService);

            //act
            IEnumerable<double> solvedVector = colleyMatrixService.Solve();

            //assert
            A.CallTo(() => matrixProvider.LowerUpperFactorizeAndSolve(null)).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_ComputeColleyRating_ForStandardInput()
        {
            //arrange
            double wins = 0;
            double losses = 1;
            double expectedOutput = 0.5;
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = A.Fake<IValidatorService>();
            IColleyMatrixService colleyMatrixService = new ColleyMatrixService(matrixProvider, validatorService);
            
            //act
            double actualOutput = colleyMatrixService.ComputeColleyRating(wins, losses);

            //assert
            actualOutput.ShouldBeEquivalentTo(expectedOutput);
        }
    }
}