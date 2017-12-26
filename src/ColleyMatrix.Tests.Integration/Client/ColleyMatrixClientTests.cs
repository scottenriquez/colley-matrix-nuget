using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace ColleyMatrix.Tests.Integration.Client
{
    [TestFixture]
    public class ColleyMatrixClientTests
    {
        [Test]
        public void Should_SimulateGameAndSolve_ForStandardInput()
        {
            //arrange
            int winnerId = 4;
            int loserId = 2;
            IEnumerable<double> expectedOutput = new double[] {0.5, 0.5, 0.375, 0.5, 0.6250000000000001}; 
            C colley = new C(5);
            
            //act
            colley.SimulateGame(winnerId, loserId);
            IEnumerable<double> actualOutput = colley.Solve();

            //assert
            actualOutput.ShouldAllBeEquivalentTo(expectedOutput);
        }
    }
}