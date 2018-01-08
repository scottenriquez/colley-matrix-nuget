namespace ColleyMatrix.Exception
{
    /// <summary>
    /// An exception thrown when an invalid team index is supplied to a function
    /// </summary>
    public class InvalidTeamIndexException : System.Exception
    {
        private readonly int _teamId;
        public string Message { get; set; }
        
        public InvalidTeamIndexException(int teamId)
        {
            _teamId = teamId;
            Message = $"The team ID {_teamId} is invalid. IDs must be greater than zero and within the matrix dimensions";
        }

        public override string ToString()
        {
            return Message;
        }
    }
}