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
            int numberOfTeams = 5;
            int winnerId = 4;
            int loserId = 2;
            IEnumerable<double> expectedOutput = new double[] {0.5, 0.5, 0.375, 0.5, 0.6250000000000001}; 
            ColleyMatrix colleyMatrix = new ColleyMatrix(numberOfTeams);
            
            //act
            colleyMatrix.SimulateGame(winnerId, loserId);
            IEnumerable<double> actualOutput = colleyMatrix.Solve();

            //assert
            actualOutput.ShouldAllBeEquivalentTo(expectedOutput);
        }
    }
}