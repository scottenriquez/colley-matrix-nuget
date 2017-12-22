using Newtonsoft.Json;

namespace ColleyMatrix.Provider
{
    /// <summary>
    /// Abstraction for serializing object to JSON
    /// </summary>
    public class JsonSerializationProvider : IJsonSerializationProvider
    {
        /// <summary>
        /// Serializes object to JSON
        /// </summary>
        /// <param name="objectToSerialize">Object to serialize</param>
        /// <returns>JSON string</returns>
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}