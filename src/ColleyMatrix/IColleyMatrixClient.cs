using System.Collections.Generic;

namespace ColleyMatrix
{
    /// <summary>
    /// A client for managing and solving a sparse matrix as described in the Colley whitepaper
    /// </summary>
    public interface IColleyMatrixClient
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
    }
}