using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSignature.Core
{
    public sealed class SignatureManager
    {
        private readonly ITimeStampGenerator _timeStampGenerator;
        private readonly ITimeStampValidator _timeStampValidator;
        private readonly IHashAlgorithm _hashAlgorithm;
        private readonly ISignatureCombiner _signatureAlgorithm;

        private readonly IApiKeyManager _apiKeyManager;


        #region 建構函式
        public SignatureManager(IApiKeyManager apiKeyManager) : this(new DefaultTimeStampGenerator()
                                                                    , new DefaultTimeStampValidator()
                                                                    , new DefaultHashAlgorithm()
                                                                    , new DefaultSignatureCombiner()
                                                                    , apiKeyManager)
        { }

        public SignatureManager(ITimeStampGenerator timeStampGenerator
                                , ITimeStampValidator timeStampValidator
                                , IHashAlgorithm hashAlgorithm
                                , ISignatureCombiner signatureAlgorithm
                                , IApiKeyManager apiKeyManager)
        {
            this._timeStampGenerator = timeStampGenerator;
            this._timeStampValidator = timeStampValidator;
            this._hashAlgorithm = hashAlgorithm;
            this._signatureAlgorithm = signatureAlgorithm;

            this._apiKeyManager = apiKeyManager;
        }

        #endregion


        /// <summary>驗證簽章是否有效</summary>
        public bool ValidSignature(string apikey, string content, string signature, long timestamp)
        {
            //檢查 timestamp 是否有效
            var _hostTimeStamp = this._timeStampGenerator.GetTimeStamp();

            if(this._timeStampValidator.IsAvailable(_hostTimeStamp, timestamp) == false)
                throw new TimeStampInvalidException();


            //比較 signature 簽章是否相同
            var _comparison = StringComparison.OrdinalIgnoreCase;
            var _hostSignature = this.GetSignature(apikey, content, timestamp);

            if (string.Equals(_hostSignature
                            , signature
                            , _comparison) == true)
                return true;

            throw new SignatureInvalidException();
        }

        public string GetSignature(string apiKey, string content, long timestamp)
        {
            long _timestamp;
            string _secret;
            string _hashSource;
            string _signature;

            _timestamp = timestamp;
            _secret = this._apiKeyManager.GetSecret(apiKey);

            //{timestamp}{secret}{content}
            _hashSource = this._signatureAlgorithm.GetSignature(_timestamp, _secret, content);
            _signature = this._hashAlgorithm.Hash(_hashSource);

            return _signature;
        }

        public long GetTimeStamp()
        {
            return this._timeStampGenerator.GetTimeStamp();
        }

    }
}
