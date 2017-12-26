using System.Collections.Generic;

namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for interacting with a matrix
    /// </summary>
    public interface IMatrixProvider
    {
        /// <summary>
        /// Returns the value for the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <returns>Target value</returns>
        double GetValue(int row, int column);
        
        /// <summary>
        /// Sets a new value at the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <param name="newValue">New value</param>
        void SetValue(int row, int column, double newValue);
        
        /// <summary>
        /// Serializes underlying matrix to JSON
        /// </summary>
        /// <returns>JSON string</returns>
        string SerializeToJson();
        
        /// <summary>
        /// Returns the dimensions of the matrix
        /// </summary>
        /// <returns>Matrix dimensions</returns>
        int GetDimensions();

        /// <summary>
        /// LU factorize the underlying sparse matrix and solve
        /// </summary>
        /// <param name="colleyRatings">A list of Colley ratings for teams where the indices in the matrix correspond to the indices in the array</param>
        /// <returns>The solved LU factorized sparse matrix</returns>
        IEnumerable<double> LowerUpperFactorizeAndSolve(IEnumerable<double> colleyRatings);
    }
}