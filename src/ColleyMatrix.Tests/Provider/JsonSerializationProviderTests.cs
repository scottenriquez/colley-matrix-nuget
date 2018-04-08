using ColleyMatrix.Provider;
using ColleyMatrix.Provider.Serializer.Json.NewtonSoft;
using FluentAssertions;
using NUnit.Framework;

namespace ColleyMatrix.Tests.Provider
{
    [TestFixture]
    public class JsonSerializationProviderTests
    {
        [Test]
        public void Should_Serialize_ForStandardInput()
        {
            //arrange
            string expectedJson = "[[0,0],[0,0]]";
            int dimensions = 2;
            int[,] matrix = new int[dimensions, dimensions];
            IJsonSerializationProvider jsonSerializationProvider = new NewtonSoftJsonSerializationProvider();
            
            //act
            string outputJson = jsonSerializationProvider.Serialize(matrix);

            //assert
            outputJson.Should().Be(expectedJson);
        }
        
        [Test]
        public void Should_Serialize_ForNullInput()
        {
            //arrange
            string expectedJson = "null";
            int[,] matrix = null;
            IJsonSerializationProvider jsonSerializationProvider = new NewtonSoftJsonSerializationProvider();
            
            //act
            string outputJson = jsonSerializationProvider.Serialize(matrix);

            //assert
            outputJson.Should().Be(expectedJson);
        }
    }
}