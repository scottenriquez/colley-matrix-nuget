using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    public class ColleyMatrixService : IColleyMatrixService
    {
        private IMatrixProvider _matrixProvider;
        
        public ColleyMatrixService(IMatrixProvider matrixProvider)
        {
            _matrixProvider = matrixProvider;
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            throw new System.NotImplementedException();
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}