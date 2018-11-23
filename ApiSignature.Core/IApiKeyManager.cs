using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSignature.Core
{
    public interface IApiKeyManager
    {
        string GetSecret(string apikey);
    }
}
