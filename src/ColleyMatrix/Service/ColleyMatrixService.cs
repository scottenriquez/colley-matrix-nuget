using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    public class ColleyMatrixService : IColleyMatrixService
    {
        private readonly IMatrixProvider _matrixProvider;
        private readonly IValidatorService _validatorService;
        
        public ColleyMatrixService(IMatrixProvider matrixProvider, IValidatorService validatorService)
        {
            _matrixProvider = matrixProvider;
            _validatorService = validatorService;
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            _validatorService.ValidateTeam(winnerId);
            _validatorService.ValidateTeam(loserId);
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}