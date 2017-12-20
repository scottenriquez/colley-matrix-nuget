using System.Drawing.Drawing2D;

namespace ColleyMatrix.Provider
{
    public class MatrixProvider : IMatrixProvider
    {
        private Matrix _matrix;
        
        public MatrixProvider()
        {
            _matrix = new Matrix();
        }

        public void Multiply(IMatrixProvider otherMatrix)
        {
            throw new System.NotImplementedException();
        }
    }
}