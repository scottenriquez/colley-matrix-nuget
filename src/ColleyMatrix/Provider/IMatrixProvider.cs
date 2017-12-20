namespace ColleyMatrix.Provider
{
    public interface IMatrixProvider
    {
        void Multiply(IMatrixProvider otherMatrix);
    }
}