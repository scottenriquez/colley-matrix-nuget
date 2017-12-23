using ColleyMatrix.Provider;
using ColleyMatrix.Service;

namespace ColleyMatrix
{
    public class C : IColleyMatrixClient
    {
        private readonly int _numberOfTeams;
        private readonly IColleyMatrixService _colleyMatrixService;

        public C(int numberOfTeams)
        {
            _numberOfTeams = numberOfTeams;
            IJsonSerializationProvider jsonSerializationProvider = new JsonSerializationProvider();
            IMatrixProvider matrixProvider = new MatrixProvider(jsonSerializationProvider, numberOfTeams);
            IValidatorService validatorService = new ValidatorService(matrixProvider);
            _colleyMatrixService = new ColleyMatrixService(matrixProvider, validatorService);
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            _colleyMatrixService.SimulateGame(winnerId, loserId);
        }

        public void Solve()
        {
            _colleyMatrixService.Solve();
        }
    }
}