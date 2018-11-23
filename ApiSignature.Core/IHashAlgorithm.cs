namespace ApiSignature.Core
{
    public interface IHashAlgorithm
    {
        string Hash(string content);
    }
}
