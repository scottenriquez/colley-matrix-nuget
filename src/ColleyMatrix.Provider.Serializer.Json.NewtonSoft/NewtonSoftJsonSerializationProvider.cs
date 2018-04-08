using Newtonsoft.Json;

namespace ColleyMatrix.Provider.Serializer.Json.NewtonSoft
{
    /// <inheritdoc />
    public class NewtonSoftJsonSerializationProvider : IJsonSerializationProvider
    {
        /// <inheritdoc />
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}
