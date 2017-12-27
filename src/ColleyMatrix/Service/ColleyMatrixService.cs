using System.Collections.Generic;
using System.Linq;
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
                    //initialize all ratings to 1
                    ColleyRating = 1
                });
            }
        }
        
        public void SimulateGame(int winnerId, int loserId)
        {
            _validatorService.ValidateTeam(winnerId);
            _validatorService.ValidateTeam(loserId);
            double gameCount = _matrixProvider.GetValue(winnerId, loserId);
            _matrixProvider.SetValue(winnerId, loserId, gameCount - 1);
            _matrixProvider.SetValue(loserId, winnerId, gameCount - 1);
            _matrixProvider.SetValue(winnerId, winnerId, _matrixProvider.GetValue(winnerId, winnerId) + 1);
            _matrixProvider.SetValue(loserId, loserId, _matrixProvider.GetValue(loserId, loserId) + 1);
            _teams[winnerId].Wins++;
            _teams[loserId].Losses++;
            _teams[winnerId].ColleyRating = ComputeColleyRating(_teams[winnerId].Wins, _teams[winnerId].Losses);
            _teams[loserId].ColleyRating = ComputeColleyRating(_teams[loserId].Wins, _teams[loserId].Losses);
        }

        public IEnumerable<double> Solve()
        {
            IEnumerable<double> colleyRatings = _teams.Select(team => team.ColleyRating);
            return _matrixProvider.LowerUpperFactorizeAndSolve(colleyRatings);
        }

        public double ComputeColleyRating(double wins, double losses)
        {
            return 1 + (wins - losses) / 2;
        }
    }
}