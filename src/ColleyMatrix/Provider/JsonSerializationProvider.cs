using Newtonsoft.Json;

namespace ColleyMatrix.Provider
{
    /// <inheritdoc />
    public class JsonSerializationProvider : IJsonSerializationProvider
    {
        /// <inheritdoc />
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}