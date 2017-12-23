using ColleyMatrix.Exception;
using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    public class ValidatorService : IValidatorService
    {
        private readonly IMatrixProvider _matrixProvider;

        public ValidatorService(IMatrixProvider matrixProvider)
        {
            _matrixProvider = matrixProvider;
        }
        
        public void ValidateTeam(int teamId)
        {
            int dimensions = _matrixProvider.GetDimensions();
            if (!(teamId < dimensions) || teamId < 0)
            {
                throw new InvalidTeamIndexException(teamId);
            }
        }
    }
}