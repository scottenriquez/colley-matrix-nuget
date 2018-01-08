namespace ColleyMatrix.Model
{
    /// <summary>
    /// A model for metadata about a team
    /// </summary>
    public class Team
    {
        public int TeamId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double ColleyRating { get; set; }
    }
}