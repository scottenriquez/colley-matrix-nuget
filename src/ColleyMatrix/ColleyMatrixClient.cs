using ColleyMatrix.Provider;
using ColleyMatrix.Service;

namespace ColleyMatrix
{
    public class ColleyMatrixClient : IColleyMatrixClient
    {
        private readonly int _numberOfTeams;
        private readonly IColleyMatrixService _colleyMatrixService;

        public ColleyMatrixClient(int numberOfTeams)
        {
            _numberOfTeams = numberOfTeams;
            _colleyMatrixService = new ColleyMatrixService(new MatrixProvider());
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