namespace ApiSignature.Core
{
    public sealed class DefaultSignatureCombiner : ISignatureCombiner
    {
        public string GetSignature(long timestamp, string secret, string content)
        {
            return string.Format("{0}{1}{2}", timestamp, secret, content);
        }
    }
}
