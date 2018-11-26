using System;
using Xunit;


namespace ApiSignature.Core.Test
{
    public sealed class DefaultHashAlgorithmTest
    {
        private readonly IHashAlgorithm _hashAlgorithm;

        public DefaultHashAlgorithmTest()
        {
            this._hashAlgorithm = new DefaultHashAlgorithm();
        }

        [Fact]
        public void Can_Get_Hash_Value()
        {
            string _content;

            _content = @"0secret{""Account"":""txstudio@outlook.com""}";

            string _expected;
            string _actual;

            _expected = "825a3e02e3639cae190e47bcb3794ba0c08e9421f796a205bb913c6b01eeed08";
            _actual = this._hashAlgorithm.Hash(_content);

            Assert.Equal(_expected, _actual);
        }

        [Fact]
        public void Can_Throw_Exception_When_Content_Is_StringEmpty()
        {
            string _content;

            _content = string.Empty;

            string _actual;
            
            Assert.Throws<ArgumentNullException>(() => {
                _actual = this._hashAlgorithm.Hash(_content);
            });
        }
    }
}
