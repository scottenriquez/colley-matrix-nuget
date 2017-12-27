using System.Collections.Generic;
using ColleyMatrix.Provider;
using ColleyMatrix.Service;

namespace ColleyMatrix
{
    public class ColleyMatrix : IColleyMatrixClient
    {
        private readonly int _numberOfTeams;
        private readonly IColleyMatrixService _colleyMatrixService;

        public ColleyMatrix(int numberOfTeams)
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

        public IEnumerable<double> Solve()
        {
            return _colleyMatrixService.Solve();
        }
    }
}