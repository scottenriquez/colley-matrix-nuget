using System.Collections.Generic;

namespace ColleyMatrix.Service
{
    public interface IColleyMatrixService
    {
        void SimulateGame(int winnerId, int loserId);
        IEnumerable<double> Solve();
        double ComputeColleyRating(double wins, double losses);
    }
}