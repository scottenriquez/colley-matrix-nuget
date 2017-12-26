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

            //act

            //assert
        }

        [Test]
        public void Should_ComputeRating_ForStandardInput()
        {
            //arrange

            //act

            //assert
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