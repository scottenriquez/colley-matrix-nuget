using System.Collections.Generic;
using ColleyMatrix.Provider;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ColleyMatrix.Tests.Provider
{
    [TestFixture]
    public class MatrixProviderTests
    {        
        [Test]
        public void Should_InitializeColleyMatrix_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.InitializeColleyMatrix();
            
            //assert
            matrixProvider.GetValue(0, 0).ShouldBeEquivalentTo(2);
            matrixProvider.GetValue(0, 1).ShouldBeEquivalentTo(0);
            matrixProvider.GetValue(1, 0).ShouldBeEquivalentTo(0);
            matrixProvider.GetValue(1, 1).ShouldBeEquivalentTo(2);
        }
        
        [Test]
        public void ShouldNot_InitializeColleyMatrix_AfterBeingInitialized()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.InitializeColleyMatrix();
            matrixProvider.SetValue(0, 0, 3);
            matrixProvider.SetValue(0, 1, 3);
            matrixProvider.SetValue(1, 0, 3);
            matrixProvider.SetValue(1, 1, 3);
            matrixProvider.InitializeColleyMatrix();
            
            //assert
            matrixProvider.GetValue(0, 0).ShouldBeEquivalentTo(3);
            matrixProvider.GetValue(0, 1).ShouldBeEquivalentTo(3);
            matrixProvider.GetValue(1, 0).ShouldBeEquivalentTo(3);
            matrixProvider.GetValue(1, 1).ShouldBeEquivalentTo(3);
        }
        
        [Test]
        public void Should_SerializeToJson_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.InitializeColleyMatrix();
            matrixProvider.SerializeToJson();
            
            //assert
            A.CallTo(() => jsonSerializationProvider.Serialize(null)).WithAnyArguments().MustHaveHappened();
        }

        [Test]
        public void Should_LowerUpperFactorization_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            double[] ratings = new double[] {0.5, 0.5};
            double[] expectedOutput = new double[] {0.25, 0.25};
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.InitializeColleyMatrix();
            matrixProvider.SerializeToJson();
            IEnumerable<double> actualOutput = matrixProvider.LowerUpperFactorizeAndSolve(ratings);
            
            //assert
            actualOutput.ShouldAllBeEquivalentTo(expectedOutput);
        }
    }
}