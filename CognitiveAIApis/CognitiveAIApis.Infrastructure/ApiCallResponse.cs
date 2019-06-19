using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Infrastructure
{
    public class ApiCallResponse<TResponse>
    {
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> ContentAsKeyValuePairs { get; set; }
        TResponse ResponseObject;
    }
}
