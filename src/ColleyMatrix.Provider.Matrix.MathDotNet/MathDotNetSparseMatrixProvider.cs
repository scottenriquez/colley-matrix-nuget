using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace ColleyMatrix.Provider.Matrix.MathDotNet
{
    /// <inheritdoc />
    public class MathDotNetSparseMatrixProvider : IMatrixProvider
    {
        private readonly IJsonSerializationProvider _jsonSerializationProvider;
        private readonly int _dimensions;
        private readonly SparseMatrix _sparseMatrix;

        /// <summary>
        /// Constructor for MathDotNetSparseMatrixProvider; initializes the sparse matrix such that M[i][i] = 2 + n
        /// </summary>
        /// <param name="jsonSerializationProvider">Serialization provider</param>
        /// <param name="dimensions">Number of rows and columns</param>
        public MathDotNetSparseMatrixProvider(IJsonSerializationProvider jsonSerializationProvider, int dimensions)
        {
            _jsonSerializationProvider = jsonSerializationProvider;
            _dimensions = dimensions;
            _sparseMatrix = SparseMatrix.CreateDiagonal(_dimensions, _dimensions, 2);
        }

        /// <inheritdoc />
        public double GetValue(int row, int column)
        {
            return _sparseMatrix.At(row, column);
        }

        /// <inheritdoc />
        public void SetValue(int row, int column, double newValue)
        {
            _sparseMatrix.At(row, column, newValue);
        }

        /// <inheritdoc />
        public string SerializeToJson()
        {
            return _jsonSerializationProvider.Serialize(_sparseMatrix.ToColumnArrays());
        }

        /// <inheritdoc />
        public int GetDimensions()
        {
            return _dimensions;
        }

        /// <inheritdoc />
        public IEnumerable<double> LowerUpperFactorizeAndSolve(IEnumerable<double> colleyRatings)
        {
            LU<double> lowerUpper = _sparseMatrix.LU();
            Vector ratingsVector = new DenseVector(colleyRatings.ToArray());
            Vector<double> solvedVector = lowerUpper.Solve(ratingsVector);
            return solvedVector.AsArray();
        }
    }
}
