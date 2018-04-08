using System;
using ColleyMatrix.Exception;
using ColleyMatrix.Provider;
using ColleyMatrix.Service;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ColleyMatrix.Tests.Service
{
    [TestFixture]
    public class ValidatorServiceTests
    {
        [Test]
        public void Should_ValidateTeam_ForValidInput()
        {
            //arrange
            int dimensions = 2;
            int teamId = 1;
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = new ValidatorService(matrixProvider);
            A.CallTo(() => matrixProvider.GetDimensions()).Returns(dimensions);
            
            //act
            Action action = () => validatorService.ValidateTeam(teamId);
            
            //assert
            action.Should().NotThrow<InvalidTeamIndexException>();
        }
        
        [Test]
        public void ShouldNot_ValidateTeam_ForLessThanZeroInput()
        {
            //arrange
            int dimensions = 2;
            int teamId = -1;
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = new ValidatorService(matrixProvider);
            A.CallTo(() => matrixProvider.GetDimensions()).Returns(dimensions);
            
            //act
            Action action = () => validatorService.ValidateTeam(teamId);
            
            //assert
            action.Should().Throw<InvalidTeamIndexException>();
        }
        
        [Test]
        public void ShouldNot_ValidateTeam_ForGreaterThanDimensionInput()
        {
            //arrange
            int dimensions = 2;
            int teamId = 2;
            IMatrixProvider matrixProvider = A.Fake<IMatrixProvider>();
            IValidatorService validatorService = new ValidatorService(matrixProvider);
            A.CallTo(() => matrixProvider.GetDimensions()).Returns(dimensions);
            
            //act
            Action action = () => validatorService.ValidateTeam(teamId);
            
            //assert
            action.Should().Throw<InvalidTeamIndexException>();
        }
    }
}