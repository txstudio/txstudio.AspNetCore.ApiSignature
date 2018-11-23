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
        public void HostGreaterThanClientOutOfRang()
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
        public void HostGreaterThanClientInRange()
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
        public void ClientGreaterThanHostOutOfRang()
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
        public void ClientGreaterThanHostInRange()
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
        public void ClientEqualHost()
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
