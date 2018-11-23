using System;

namespace ApiSignature.Core
{

    public sealed class DefaultTimeStampValidator : ITimeStampValidator
    {
        private readonly int _rangeSecond = 300;

        /// <summary>初始化時間戳記驗證 (預設驗證差異時間:300 sec)</summary>
        /// <param name="rangeSecond"></param>
        public DefaultTimeStampValidator(int? rangeSecond = null)
        {
            if (rangeSecond.HasValue == true)
                this._rangeSecond = rangeSecond.Value;
        }

        /// <summary>判斷 timestamp 是否有效</summary>
        /// <param name="hostTimeStamp">伺服器的時間戳記</param>
        /// <param name="clientTimeStamp">呼叫端的時間戳記</param>
        public bool IsAvailable(long hostTimeStamp, long clientTimeStamp)
        {
            long _diff;

            _diff = hostTimeStamp - clientTimeStamp;
            _diff = Math.Abs(_diff);

            if (_diff > this._rangeSecond)
                return false;

            return true;
        }
    }
}
