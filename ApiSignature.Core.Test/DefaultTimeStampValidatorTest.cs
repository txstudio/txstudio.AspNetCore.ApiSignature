using System;
using Xunit;

namespace ApiSignature.Core.Test
{
    public sealed class DefaultTimeStampValidatorTest
    {
        private readonly long _outOfRangeSecond = 301;
        private readonly long _inRangeSecond = 300;

        private readonly ITimeStampValidator _timestampValidator;

        public DefaultTimeStampValidatorTest()
        {
            this._timestampValidator = new DefaultTimeStampValidator();
        }

        [Fact]
        public void Can_Get_False_When_Host_Timestampe_Greater_Than_Client()
        {
            long _host;
            long _client;

            _host = 32767 + _outOfRangeSecond;
            _client = 32767;

            bool _expected;
            bool _actual;

            _expected = false;
            _actual = this._timestampValidator.IsAvailable(_host, _client);

            Assert.Equal<bool>(_expected, _actual);
        }

        [Fact]
        public void Can_Get_True_When_Host_Timstamp_Greater_Than_Client_But_InRange()
        {
            long _host;
            long _client;

            _host = 32767 + _inRangeSecond;
            _client = 32767;

            bool _expected;
            bool _actual;

            _expected = true;
            _actual = this._timestampValidator.IsAvailable(_host, _client);

            Assert.Equal<bool>(_expected, _actual);
        }

        [Fact]
        public void Can_Get_False_When_Client_Timestamp_Greater_Than_Host()
        {
            long _host;
            long _client;

            _host = 32767;
            _client = 32767 + _outOfRangeSecond;

            bool _expected;
            bool _actual;

            _expected = false;
            _actual = this._timestampValidator.IsAvailable(_host, _client);

            Assert.Equal<bool>(_expected, _actual);
        }

        [Fact]
        public void Can_Get_True_When_Client_Timestamp_Greater_Than_Host_But_InRange()
        {
            long _host;
            long _client;

            _host = 32767;
            _client = 32767 + _inRangeSecond;

            bool _expected;
            bool _actual;

            _expected = true;
            _actual = this._timestampValidator.IsAvailable(_host, _client);

            Assert.Equal<bool>(_expected, _actual);
        }
        
        [Fact]  
        public void Can_Get_True_When_Client_Equal_Host()
        {
            long _host;
            long _client;

            _host = 32767;
            _client = 32767;

            bool _expected;
            bool _actual;

            _expected = true;
            _actual = this._timestampValidator.IsAvailable(_host, _client);

            Assert.Equal<bool>(_expected, _actual);
        }

    }
}
