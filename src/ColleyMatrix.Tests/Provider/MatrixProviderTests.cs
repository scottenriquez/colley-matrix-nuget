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
        public void Should_ConstructMatrixProvider_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            
            //act
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //assert
            matrixProvider.GetValue(0, 0).ShouldBeEquivalentTo(2);
            matrixProvider.GetValue(0, 1).ShouldBeEquivalentTo(0);
            matrixProvider.GetValue(1, 0).ShouldBeEquivalentTo(0);
            matrixProvider.GetValue(1, 1).ShouldBeEquivalentTo(2);
        }
        
        [Test]
        public void Should_SerializeToJson_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
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
            matrixProvider.SerializeToJson();
            IEnumerable<double> actualOutput = matrixProvider.LowerUpperFactorizeAndSolve(ratings);
            
            //assert
            actualOutput.ShouldAllBeEquivalentTo(expectedOutput);
        }
    }
}