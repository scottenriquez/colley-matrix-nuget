using System.Collections.Generic;
using ColleyMatrix.Model;
using ColleyMatrix.Provider;

namespace ColleyMatrix.Service
{
    public class ColleyMatrixService : IColleyMatrixService
    {
        private readonly IMatrixProvider _matrixProvider;
        private readonly IValidatorService _validatorService;
        private readonly int _dimensions;
        private readonly IList<Team> _teams;
        
        public ColleyMatrixService(IMatrixProvider matrixProvider, IValidatorService validatorService)
        {
            _matrixProvider = matrixProvider;
            _validatorService = validatorService;
            _dimensions = _matrixProvider.GetDimensions();
            _teams = new List<Team>();
            for (int teamId = 0; teamId < _dimensions; teamId++)
            {
                _teams.Add(new Team()
                {
                    TeamId = teamId,
                    Wins = 0,
                    Losses = 0,
                    ColleyRating = 1
                });
            }
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            _validatorService.ValidateTeam(winnerId);
            _validatorService.ValidateTeam(loserId);
            int gameCount = _matrixProvider.GetValue(winnerId, loserId);
            _matrixProvider.SetValue(winnerId, loserId, gameCount - 1);
            _matrixProvider.SetValue(loserId, winnerId, gameCount - 1);
            //TODO: update ratings and wins/losses
        }

        public void Solve()
        {
            throw new System.NotImplementedException();
        }
    }
}