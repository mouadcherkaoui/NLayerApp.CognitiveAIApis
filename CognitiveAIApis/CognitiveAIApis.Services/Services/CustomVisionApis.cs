using CognitiveAIApis.Models.CustomVision;
using CognitiveAIApis.Services.Helpers;
using CognitiveAIApis.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveAIApis.Services
{
    public class CustomVisionApis
    {
        private readonly string _endpointUri;
        private readonly string _subscriptionKey;
        private readonly string _version;
        private readonly Dictionary<string, string> _headers;


        public CustomVisionApis(string endpointUri, string version, string subscriptionKey, string trainingKey = "5363dc26ffc645eaaf0c2e6af1d87dd4")
        {
            _endpointUri = $"{endpointUri}/customvision";
            _version = version;
            _subscriptionKey = subscriptionKey;

            _headers = 
                new Dictionary<string, string>
                {
                    { "Ocp-Apim-Subscription-Key", _subscriptionKey},
                    { "Accept", "application/json" }
                }
                .with("TrainingKey", trainingKey);
        }

        public CustomVisionApis(ApiCredential credential) : this(credential.Endpoint, credential.Version, credential.SubscriptionKey) { }

        public async Task<CreateProjectResult> CreateProjectAsync(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new ApiDictionary()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", "projects" },
                    { "Headers", _headers.with("ContentType", "application/json") }, 
                        // .Append(new KeyValuePair<string, string> ("ContentType", "application/json")) // the with extension method is an abreviation of the two operations
                        // .ToDictionary(kv => kv.Key, kv => kv.Value) },                                // of appending and reconverting the result back from IEnumerable to Dictionary
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "name", "testProject" }
                        }
                    },
                    { "RequestObject", objectToProcess }
                };

            var preRequestAction = new Func<HttpResponseMessage, object>((response) =>
            {
                var content = response.Content;
                var json = content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject(json);
                return result;
            });
            return
                await RequestProcessor
                    .ProcessRequest<object, CreateProjectResult>(requestDictionary);
        }

        public async Task<CreateTagResult> CreateTagAsync(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/tags" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "name", objectToProcess.tagName }
                        }
                    },
                    { "RequestObject", objectToProcess }
                };

            return
                await RequestProcessor
                    .ProcessRequest<object, CreateTagResult>(
                        requestDictionary);
        }

        public async Task<CreateImagesResult> CreateImagesFromUrlsAsync(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/images/urls" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "name", "testTag" }
                        }
                    },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, CreateImagesResult>(
                        requestDictionary);
        }

        public async Task<CreateImagesResult> CreateImagesAsync(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/images/urls" },
                    { "Headers", _headers.with("ContentType", "application/octet-stream") },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "name", "testTag" }
                        }
                    },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, CreateImagesResult>(
                        requestDictionary);
        }

        public async Task<TrainingResult> TrainProjectAsync(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/train" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, TrainingResult>(
                        requestDictionary);
        }

        public async Task<List<Iteration>> GetIterations(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "GET" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/iterations" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, List<Iteration>>(
                        requestDictionary);
        }

        public async Task<object> UpdateIteration(dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "PATCH" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/iterations/{objectToProcess.iterationId}" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "RequestObject", objectToProcess.iteration }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, object>(
                        requestDictionary);
        }

        public async Task<QuickTestResult> QuickTestImageWithUrlAsync(string iterationId, string projectId, 
            dynamic objectToProcess = null, 
            Dictionary<string, string> parameters = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{_endpointUri}" },
                    { "Endpoint_Version", _version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{projectId}/quicktest/url" },
                    { "Headers", _headers.with("ContentType", "application/json") },
                    { "Parameters", 
                        new Dictionary<string, string>{
                            { "iterationId", iterationId }
                        }
                    },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, QuickTestResult>(
                        requestDictionary);
        }



    }
}
