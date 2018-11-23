using System;
using System.Security.Cryptography;
using System.Text;

namespace ApiSignature.Core
{
    public class DefaultHashAlgorithm : IHashAlgorithm
    {
        private readonly Encoding _encoding;

        public DefaultHashAlgorithm()
        {
            this._encoding = Encoding.GetEncoding("utf-8");
        }

        public string Hash(string content)
        {
            string _result;
            byte[] _buffer;
            byte[] _hashBytes;

            if (string.IsNullOrWhiteSpace(content) == true)
                throw new ArgumentNullException("content");

            _result = string.Empty;
            _buffer = this._encoding.GetBytes(content);

            using (SHA256 _hash = SHA256.Create())
            {
                _hashBytes = _hash.ComputeHash(_buffer);

                _result = BitConverter.ToString(_hashBytes);
                _result = _result.Replace("-", string.Empty);
                _result = _result.ToLower();
            }

            return _result;
        }
    }
}
