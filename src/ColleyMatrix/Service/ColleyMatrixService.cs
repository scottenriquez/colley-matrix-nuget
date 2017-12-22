using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    public class ColleyMatrixService : IColleyMatrixService
    {
        private IMatrixProvider _matrixProvider;
        private IValidatorService _validatorService;
        
        public ColleyMatrixService(IMatrixProvider matrixProvider, IValidatorService validatorService)
        {
            _matrixProvider = matrixProvider;
            _validatorService = validatorService;
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            _validatorService.ValidateTeams(winnerId, loserId);
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}