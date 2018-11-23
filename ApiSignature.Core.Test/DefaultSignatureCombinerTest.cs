using System;
using Xunit;

namespace ApiSignature.Core.Test
{
    public sealed class DefaultSignatureCombinerTest
    {
        private readonly ISignatureCombiner _signatureCombiner;

        public DefaultSignatureCombinerTest()
        {
            this._signatureCombiner = new DefaultSignatureCombiner();
        }

        [Fact]
        public void GetSignatureOrigin()
        {
            long _timestamp;
            string _secret;
            string _content;

            _timestamp = 0;
            _secret = "secret";
            _content = @"{""Account"":""txstudio@outlook.com""}";

            string _expected;
            string _acutal;

            _expected = @"0secret{""Account"":""txstudio@outlook.com""}";
            _acutal = this._signatureCombiner.GetSignature(_timestamp, _secret, _content);

            Assert.Equal(_expected, _acutal);
        }
    }
}
