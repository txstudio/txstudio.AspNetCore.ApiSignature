using System;

namespace ApiSignature.Core
{
    public interface ITimeStampGenerator
    {
        long GetTimeStamp(Nullable<DateTime> datetime = null);
    }
}
