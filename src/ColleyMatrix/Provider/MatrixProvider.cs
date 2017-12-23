using System.Drawing.Drawing2D;

namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for interacting with a matrix
    /// </summary>
    public class MatrixProvider : IMatrixProvider
    {
        private readonly IJsonSerializationProvider _jsonSerializationProvider;
        private readonly int _dimensions;
        private readonly int[,] _matrix;
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
            _matrix = new int[dimensions, dimensions];
            _isInitialized = false;
        }
        
        /// <summary>
        /// Initializes the matrix such that M[i][i] = 2 + n
        /// </summary>
        public void InitializeColleyMatrix()
        {
            if (!_isInitialized)
            {
                for (int row = 0; row < _dimensions; row++)
                {
                    for (int column = 0; column < _dimensions; column++)
                    {
                        _matrix[row, column] += 2;
                    }
                }
                _isInitialized = true;
            }
        }
        
        /// <summary>
        /// Returns the value for the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <returns>Target value</returns>
        public int GetValue(int row, int column)
        {
            return _matrix[row, column];
        }
        
        /// <summary>
        /// Sets a new value at the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <param name="newValue">New value</param>
        public void SetValue(int row, int column, int newValue)
        {
            _matrix[row, column] = newValue;
        }
        
        /// <summary>
        /// Serializes underlying matrix to JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public string SerializeToJson()
        {
            return _jsonSerializationProvider.Serialize(_matrix);
        }

        /// <summary>
        /// Returns the dimensions of the matrix
        /// </summary>
        /// <returns>Matrix dimensions</returns>
        public int GetDimensions()
        {
            return _dimensions;
        }
    }
}