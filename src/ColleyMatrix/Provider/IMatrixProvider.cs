namespace ColleyMatrix.Provider
{
    public interface IMatrixProvider
    {
        void InitializeColleyMatrix();
        int GetValue(int row, int column);
        void SetValue(int row, int column, int newValue);
        string SerializeToJson();
    }
}