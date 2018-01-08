namespace ColleyMatrix.Service
{
    /// <summary>
    /// A service for validating input and output for Colley logic and calculations
    /// </summary>
    public interface IValidatorService
    {
        /// <summary>
        /// Ensures that the team ID supplied is valid
        /// </summary>
        /// <param name="teamId"></param>
        void ValidateTeam(int teamId);
    }
}