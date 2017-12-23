namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for interacting with a matrix
    /// </summary>
    public interface IMatrixProvider
    {
        /// <summary>
        /// Initializes the matrix such that M[i][i] = 2 + n
        /// </summary>
        void InitializeColleyMatrix();
        
        /// <summary>
        /// Returns the value for the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <returns>Target value</returns>
        int GetValue(int row, int column);
        
        /// <summary>
        /// Sets a new value at the specified row and column
        /// </summary>
        /// <param name="row">X value</param>
        /// <param name="column">Y value</param>
        /// <param name="newValue">New value</param>
        void SetValue(int row, int column, int newValue);
        
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
    }
}