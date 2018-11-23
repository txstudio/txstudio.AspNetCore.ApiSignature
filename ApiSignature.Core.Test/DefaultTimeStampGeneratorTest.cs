using System;
using Xunit;

namespace ApiSignature.Core.Test
{
    public sealed class DefaultTimeStampGeneratorTest
    {
        private readonly ITimeStampGenerator _timeStampGenerator;

        public DefaultTimeStampGeneratorTest()
        {
            this._timeStampGenerator = new DefaultTimeStampGenerator();
        }

        [Fact]
        public void ReturnTimeStampFromNoParameterTest()
        {
            long _timestamp;

            _timestamp = this._timeStampGenerator.GetTimeStamp();

            Assert.IsType<long>(_timestamp);
        }

        [Fact]
        public void OriginTimeStampTest()
        {
            DateTime _DefaultDateTime;
            long _timestamp;
            long _expected;

            _expected = 0;
            _DefaultDateTime = new DateTime(1970, 1, 1);
            _timestamp = this._timeStampGenerator.GetTimeStamp(_DefaultDateTime);

            Assert.Equal(_expected, _timestamp);
        }

        [Fact]
        public void StepBySecondTest()
        {
            DateTime _DefaultDateTime;
            long _timestamp;
            long _excepted;

            _excepted = 10;
            _DefaultDateTime = new DateTime(1970, 1, 1);
            _DefaultDateTime = _DefaultDateTime.AddSeconds(10);
            _timestamp = this._timeStampGenerator.GetTimeStamp(_DefaultDateTime);

            Assert.Equal(_excepted, _timestamp);
        }
    }
}
