namespace ColleyMatrix
{
    public interface IColleyMatrixClient
    {
        void SimulateGame(int winnerId, int loserId);
        void Solve();
    }
}