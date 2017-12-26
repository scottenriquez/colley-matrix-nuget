using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for interacting with a matrix
    /// </summary>
    public class MatrixProvider : IMatrixProvider
    {
        private readonly IJsonSerializationProvider _jsonSerializationProvider;
        private readonly int _dimensions;
        private SparseMatrix _sparseMatrix;
        private bool _isInitialized;
        
        /// <summary>
        /// Constructor for MatrixProvider
        /// </summary>
        /// <param name="jsonSerializationProvider">Serialization provider</param>
        /// <param name="dimensions">Number of rows and columns</param>
        public MatrixProvider(IJsonSerializationProvider jsonSerializationProvider, int dimensions)
        {
            _jsonSerializationProvider = jsonSerializationProvider;
            _dimensions = dimensions;
            _isInitialized = false;
        }
        
        /// <summary>
        /// Initializes the matrix such that M[i][i] = 2 + n
        /// </summary>
        public void InitializeColleyMatrix()
        {
            if (!_isInitialized)
            {
                _sparseMatrix = SparseMatrix.CreateDiagonal(_dimensions, _dimensions, 2);
                _isInitialized = true;
            }
        }
        
        /// <summary>
        /// Returns the value for the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <returns>Target value</returns>
        public double GetValue(int row, int column)
        {
            return _sparseMatrix.At(row, column);
        }
        
        /// <summary>
        /// Sets a new value at the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <param name="newValue">New value</param>
        public void SetValue(int row, int column, double newValue)
        {
            _sparseMatrix.At(row, column, newValue);
        }
        
        /// <summary>
        /// Serializes underlying matrix to JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public string SerializeToJson()
        {
            return _jsonSerializationProvider.Serialize(_sparseMatrix.ToColumnArrays());
        }

        /// <summary>
        /// Returns the dimensions of the matrix
        /// </summary>
        /// <returns>Matrix dimensions</returns>
        public int GetDimensions()
        {
            return _dimensions;
        }

        /// <summary>
        /// LU factorize the underlying sparse matrix and solve
        /// </summary>
        /// <param name="colleyRatings">A list of Colley ratings for teams where the indices in the matrix correspond to the indices in the array</param>
        /// <returns>The solved LU factorized sparse matrix</returns>
        public IEnumerable<double> LowerUpperFactorizeAndSolve(double[] colleyRatings)
        {
            LU<double> lowerUpper = _sparseMatrix.LU();
            Vector ratingsVector = new DenseVector(colleyRatings);
            Vector<double> solvedVector = lowerUpper.Solve(ratingsVector);
            return solvedVector.AsArray();
        }
    }
}