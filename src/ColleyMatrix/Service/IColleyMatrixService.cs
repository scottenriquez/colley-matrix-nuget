using System.Collections.Generic;

namespace ColleyMatrix.Service
{
    /// <summary>
    /// A service for executing the Colley algorithm
    /// </summary>
    public interface IColleyMatrixService
    {
        /// <summary>
        /// Update underlying sparse matrix and ratings for a game that has been played
        /// </summary>
        /// <param name="winnerId">The index of the team that won</param>
        /// <param name="loserId">The index of the team that lost</param>
        void SimulateGame(int winnerId, int loserId);
        
        /// <summary>
        /// Solve the underlying matrix using the Colley ratings vector
        /// </summary>
        /// <returns>Solved vector</returns>
        IEnumerable<double> Solve();
        
        /// <summary>
        /// Calculate the Colley rating for a team
        /// </summary>
        /// <param name="wins">Number of wins</param>
        /// <param name="losses">Number of losses</param>
        /// <returns></returns>
        double ComputeColleyRating(double wins, double losses);
    }
}