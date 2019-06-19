using CognitiveAIApis.Models.CustomVision;
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
        private const string ApiUri = "https://westus2.api.cognitive.microsoft.com/customvision";
        private const string SubscriptionKey = "8cf15696a50e46d6b5c8b8d14fabeec6";
        private const string Endpoint_Version = "v3.0";
        private const string Service = "customvision";
        private const string Text = "The food was delicious and there were wonderful staff.";
        private const string imageFilePath = "Images/image.jpg";

        private static readonly Dictionary<string, string> Headers = new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey},
                            { "Training-Key", "5363dc26ffc645eaaf0c2e6af1d87dd4" },
                            { "Accept", "application/json" }
                        };
        public static async Task<CreateProjectResult> CreateProjectAsync(object objectToProcess = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", "projects" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) },
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

        public static async Task<CreateTagResult> CreateTagAsync(dynamic objectToProcess = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/tags" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
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

        public static async Task<CreateImagesResult> CreateImagesFromUrlsAsync(dynamic objectToProcess = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/images/urls" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
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

        public static async Task<CreateImagesResult> CreateImagesAsync(dynamic objectToProcess = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/images/urls" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/octet-stream"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
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

        public static async Task<TrainingResult> TrainProjectAsync(dynamic objectToProcess = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/train" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, TrainingResult>(
                        requestDictionary);
        }

        public static async Task<List<Iteration>> GetIterations(dynamic objectToProcess = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "GET" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/iterations" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
                    { "RequestObject", objectToProcess }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, List<Iteration>>(
                        requestDictionary);
        }

        public static async Task<object> UpdateIteration(dynamic objectToProcess = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "PATCH" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{objectToProcess.projectId}/iterations/{objectToProcess.iterationId}" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
                    { "RequestObject", objectToProcess.iteration }
                };


            return
                await RequestProcessor
                    .ProcessRequest<object, object>(
                        requestDictionary);
        }

        public static async Task<QuickTestResult> QuickTestImageWithUrlAsync(string iterationId, string projectId, dynamic objectToProcess = null)
        {

            var requestDictionary = new Dictionary<string, object>()
                {
                    { "Endpoint_Uri", $"{ApiUri}" },
                    { "Endpoint_Version", Endpoint_Version },
                    { "Operation_Method", "POST" },
                    { "Operation_Path", "training" },
                    { "Operation_SubPath", $"projects/{projectId}/quicktest/url" },
                    { "Headers", Headers
                        .Append(new KeyValuePair<string, string> ("ContentType", "application/json"))
                        .ToDictionary(kv => kv.Key, kv => kv.Value) 
                    },
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

        //public static async Task<object> DetectFacesWithUrlAsync(object objectToProcess = null)
        //{
        //    var requestDictionary = new Dictionary<string, object>()
        //        {
        //            { "Endpoint_Uri", $"{ApiUri}/face" },
        //            { "Endpoint_Version", "v1.0" },
        //            { "Operation_Method", "POST" },
        //            { "RequestObject", objectToProcess },
        //            { "Operation_Path", "detect" },
        //            { "Headers",
        //                new Dictionary<string, string>
        //                {
        //                    { "Ocp-Apim-Subscription-Key", SubscriptionKey },
        //                    { "ContentType", "application/json" },
        //                    { "Accept", "application/json" }
        //                }
        //            },
        //            { "Parameters",
        //                new Dictionary<string, string>()
        //                {
        //                    { "returnRecognitionModel", "true" }
        //                }
        //            }

        //        };

        //    return
        //        await RequestProcessor
        //            .ProcessRequest(
        //                requestDictionary,
        //                GetPostRequestAction<object>(),
        //                GetPreRequestAction<List<DetectedFace>>());
        //}
        private static Func<TRequest, HttpRequestMessage> GetContentlessPostRequestAction<TRequest>()
        {
            return new Func<TRequest, HttpRequestMessage>((request) =>
            {
                var requestMessage = new HttpRequestMessage() {};

                return requestMessage;
            });
        }

        private static Func<TRequest, HttpRequestMessage> GetPostRequestAction<TRequest>()
        {
            return new Func<TRequest, HttpRequestMessage>((request) =>
            {
                var json = JsonConvert.SerializeObject(request);
                var byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            });
        }

        private static Func<TRequest, HttpRequestMessage> GetPostStreamRequestAction<TRequest>()
        {
            return (request) =>
            {
                var bytes = request as byte[];
                var byteArrayContent = new ByteArrayContent(bytes);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            };
        }

        private static Func<HttpResponseMessage, TResponse> GetPreRequestAction<TResponse>()
        {
            return new Func<HttpResponseMessage, TResponse>((responseMessage) =>
            {
                var jsonContent = responseMessage.Content.ReadAsStringAsync().Result;
                var resultToReturn = JsonConvert.DeserializeObject<TResponse>(jsonContent);
                return resultToReturn;
            });
        }
    }
}
