using System.Collections.Generic;
using ColleyMatrix.Provider;
using ColleyMatrix.Provider.Matrix.MathDotNet;
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
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            
            //assert
            matrixProvider.GetValue(0, 0).Should().Be(2);
            matrixProvider.GetValue(0, 1).Should().Be(0);
            matrixProvider.GetValue(1, 0).Should().Be(0);
            matrixProvider.GetValue(1, 1).Should().Be(2);
        }
        
        [Test]
        public void Should_GetValue_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            double expectedOutput = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            double actualOutput = matrixProvider.GetValue(0, 0);

            //assert
            actualOutput.Should().Be(expectedOutput);
        }
        
        [Test]
        public void Should_SetValue_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            double newValue = 5;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            matrixProvider.SetValue(0, 0, newValue);
            
            //act
            double actualOutput = matrixProvider.GetValue(0, 0);

            //assert
            actualOutput.Should().Be(newValue);
        }
        
        [Test]
        public void Should_SerializeToJson_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.SerializeToJson();
            
            //assert
            A.CallTo(() => jsonSerializationProvider.Serialize(null)).WithAnyArguments().MustHaveHappened();
        }
        
        [Test]
        public void Should_GetDimensions_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            double actualOutput = matrixProvider.GetDimensions();

            //assert
            actualOutput.Should().Be(dimensions);
        }

        [Test]
        public void Should_LowerUpperFactorization_ForStandardInput()
        {
            //arrange
            int dimensions = 2;
            double[] ratings = new double[] {0.5, 0.5};
            double[] expectedOutput = new double[] {0.25, 0.25};
            IJsonSerializationProvider jsonSerializationProvider = A.Fake<IJsonSerializationProvider>();
            IMatrixProvider matrixProvider = new MathDotNetSparseMatrixProvider(jsonSerializationProvider, dimensions);
            
            //act
            matrixProvider.SerializeToJson();
            IEnumerable<double> actualOutput = matrixProvider.LowerUpperFactorizeAndSolve(ratings);
            
            //assert
            actualOutput.Should().BeEquivalentTo(expectedOutput);
        }
    }
}