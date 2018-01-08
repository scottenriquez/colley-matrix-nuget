using ColleyMatrix.Exception;
using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    /// <inheritdoc />
    public class ValidatorService : IValidatorService
    {
        private readonly IMatrixProvider _matrixProvider;

        /// <summary>
        /// Instantiates a ValidatorService object
        /// </summary>
        /// <param name="matrixProvider"></param>
        public ValidatorService(IMatrixProvider matrixProvider)
        {
            _matrixProvider = matrixProvider;
        }
        
        /// <inheritdoc />
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