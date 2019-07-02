using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Infrastructure.Models
{
    public interface IRestOperation
    {
        IRestEndpoint HasEndpointUri(string endpoint);
    }
}
