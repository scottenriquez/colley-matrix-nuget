namespace ColleyMatrix.Provider
{
    public interface IJsonSerializationProvider
    {
        string Serialize(object objectToSerialize);
    }
}