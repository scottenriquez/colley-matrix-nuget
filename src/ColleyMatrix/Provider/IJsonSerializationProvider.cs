namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for serializing object to JSON
    /// </summary>
    public interface IJsonSerializationProvider
    {
        /// <summary>
        /// Serializes object to JSON
        /// </summary>
        /// <param name="objectToSerialize">Object to serialize</param>
        /// <returns>JSON string</returns>
        string Serialize(object objectToSerialize);
    }
}