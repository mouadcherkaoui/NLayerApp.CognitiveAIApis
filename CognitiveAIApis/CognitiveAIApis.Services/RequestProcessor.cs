using CognitiveAIApis.Models;
using CognitiveAIApis.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveAIApis.Services
{
    public class RequestProcessor
    {
        public static async Task<TResult> ProcessRequest<TRequest, TResult>(ApiCallCommand<TRequest, TResult> request,
            Func<HttpResponseMessage, TResult> preRequestAction = null,
            Func<TRequest, HttpRequestMessage> postRequestAction = null)
            where TResult : class
        {
            var requestHandler = new ApiCommandHandler<TRequest, TResult>(request, postRequestAction, preRequestAction);
            return await requestHandler.HandleRequestAsync();
        }

        public static async Task<TResult> ProcessRequest<TRequest, TResult>(Dictionary<string, object> requestDictionary, 
            Func<TRequest, HttpRequestMessage> postRequestAction = null,
            Func<HttpResponseMessage, TResult> preRequestAction = null)
            where TResult : class
        {
            var request = new ApiCallCommand<TRequest, TResult>((TRequest)requestDictionary["RequestObject"]);
            requestDictionary.Remove("RequestObject");
            var requestType = typeof(ApiCallCommand<TRequest, TResult>);
            foreach (var item in requestDictionary)
            {
                var property = requestType.GetProperty(item.Key);
                requestType.GetProperty(item.Key).SetValue(request, item.Value);
            }

            var requestHandler = new ApiCommandHandler<TRequest, TResult>(request, postRequestAction, preRequestAction);
            return await requestHandler.HandleRequestAsync();
        }

        public static async Task<ResponseWrapper<TResult>> ProcessRequest<TResult>(Dictionary<string, object> requestDictionary,
            Func<Dictionary<string, object>, HttpRequestMessage> postRequestAction = null,
            Func<HttpResponseMessage, ResponseWrapper<TResult>> preRequestAction = null)
            where TResult : class
        {

            var requestHandler = new ApiDictHandler<TResult>(requestDictionary, postRequestAction, preRequestAction);
            return await requestHandler.HandleRequestAsync();
        }
    }
}
