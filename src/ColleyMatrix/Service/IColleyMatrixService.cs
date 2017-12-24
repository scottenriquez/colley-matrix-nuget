namespace ColleyMatrix.Service
{
    public interface IColleyMatrixService
    {
        void SimulateGame(int winnerId, int loserId);
        void Solve();
        decimal ComputeRating(int wins, int losses);
    }
}