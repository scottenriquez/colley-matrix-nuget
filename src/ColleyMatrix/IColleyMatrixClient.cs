using System.Collections.Generic;

namespace ColleyMatrix
{
    public interface IColleyMatrixClient
    {
        void SimulateGame(int winnerId, int loserId);
        IEnumerable<double> Solve();
    }
}