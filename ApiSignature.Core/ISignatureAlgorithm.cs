namespace ApiSignature.Core
{
    public interface ISignatureCombiner
    {
        string GetSignature(long timestamp, string secret, string content);
    }
}
