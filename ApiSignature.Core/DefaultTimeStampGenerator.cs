using System;

namespace ApiSignature.Core
{
    public sealed class DefaultTimeStampGenerator : ITimeStampGenerator
    {
        public long GetTimeStamp(DateTime? datetime = null)
        {
            var _current = DateTime.UtcNow;

            if (datetime.HasValue == true)
                _current = datetime.Value;

            var _offset = new DateTimeOffset(_current, TimeSpan.FromSeconds(0));
            var _timestamp = _offset.ToUnixTimeSeconds();

            return _timestamp;
        }
    }
}
