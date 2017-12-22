using System.Drawing.Drawing2D;

namespace ColleyMatrix.Provider
{
    public class MatrixProvider : IMatrixProvider
    {
        private readonly IJsonSerializationProvider _jsonSerializationProvider;
        private readonly int _dimensions;
        private readonly int[,] _matrix;
        private bool _isInitialized;
        
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

        public int GetValue(int row, int column)
        {
            return _matrix[row, column];
        }

        public void SetValue(int row, int column, int newValue)
        {
            _matrix[row, column] = newValue;
        }

        public string SerializeToJson()
        {
            return _jsonSerializationProvider.Serialize(_matrix);
        }
    }
}