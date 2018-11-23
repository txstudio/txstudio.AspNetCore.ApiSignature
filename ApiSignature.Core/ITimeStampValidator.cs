namespace ApiSignature.Core
{
    public interface ITimeStampValidator
    {
        bool IsAvailable(long hostTimeStamp, long clientTimeStamp);
    }
}
