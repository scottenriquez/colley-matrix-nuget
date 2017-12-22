using ColleyMatrix.Provider;
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
            IJsonSerializationProvider jsonSerializationProvider = new JsonSerializationProvider();
            
            //act
            string outputJson = jsonSerializationProvider.Serialize(matrix);

            //assert
            outputJson.ShouldBeEquivalentTo(expectedJson);
        }
        
        [Test]
        public void Should_Serialize_ForNullInput()
        {
            //arrange
            string expectedJson = "null";
            int[,] matrix = null;
            IJsonSerializationProvider jsonSerializationProvider = new JsonSerializationProvider();
            
            //act
            string outputJson = jsonSerializationProvider.Serialize(matrix);

            //assert
            outputJson.ShouldBeEquivalentTo(expectedJson);
        }
    }
}