using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Infrastructure
{
    public class ResponseWrapper<TResponse>
    {
        public string StatusCode { get; set; }
        public bool IsSuccessfull { get; set; }
        public string ReasonPhrase { get; set; }
        public TResponse ResponseContent{ get; set; }
    }
}
