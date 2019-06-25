using CognitiveAIApis.Infrastructure;
using CognitiveAIApis.Services.Helpers;
using CognitiveAIApis.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveAIApis.Services.Services
{
    public class SearchApis
    {
        private string endPointUri = "https://api.cognitive.microsoft.com/bing";
        private string version = "v7.0";
        private string operationSubPath = "search";
        private IOperationDefinition operationDefinition;
        public SearchApis(string subscriptionKey)
        {
            operationDefinition = new RestOperationDefinition() { };
            operationDefinition
                .WithEndpoint(endPointUri)
                .WithVersion(version)
                .WithHeaders(new Dictionary<string, string>()
                    .with("Accept", "application/json"))
                .WithSubscriptionKey(subscriptionKey);
        }

        public async Task<ResponseWrapper<object>> SearchAsync(string str)
        {
            return await operationDefinition
                .WithParameters(new Dictionary<string, string>()
                    .with("q", str))
                .WithMethod("GET")
                .WithOperationPath("search")
                .WithPayload(new { })
                .ProcessRequest<object, object>();
        }
    }
}
