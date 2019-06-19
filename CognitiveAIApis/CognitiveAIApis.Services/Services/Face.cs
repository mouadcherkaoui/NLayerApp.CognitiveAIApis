using CognitiveAIApis.Models;
using CognitiveAIApis.Infrastructure;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveAIApis.Services
{
    public class FaceApis
    {

        private const string ApiUri = "https://westus.api.cognitive.microsoft.com";
        private const string SubscriptionKey = "8cf15696a50e46d6b5c8b8d14fabeec6";
        private const string Version = "v1.0";
        private const string Text = "The food was delicious and there were wonderful staff.";
        private const string imageFilePath = "Images/image.jpg";
        public static async Task<object> DetectFaces(object objectToProcess = null)
        {
            using (FileStream fileStream = new FileStream(((dynamic)objectToProcess).imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                var bytes = binaryReader.ReadBytes((int)fileStream.Length);

                var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{ApiUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", bytes },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/octet-stream" },
                            { "Accept", "application/json" }
                        }
                    },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "returnRecognitionModel", "true" }
                        }
                    },
                    { "PostRequestAction", GetPostStreamRequestAction<byte[]>() },
                    { "PreRequestAction",  GetPreRequestAction<List<DetectedFace>>()}

                };

                return await RequestProcessor
                        .ProcessRequest(
                            requestDictionary,
                            GetPostStreamRequestAction<byte[]>(),
                            GetPreRequestAction<List<DetectedFace>>()); 
            }
        }
        public static async Task<object> DetectFacesWithUrl(object objectToProcess = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{ApiUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", objectToProcess },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        }
                    },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "returnRecognitionModel", "true" },
                            { "details", "Celebrities" }

                        }
                    }
                };
            return
                await RequestProcessor
                    .ProcessRequest(
                        requestDictionary,
                        GetPostRequestAction<object>(),
                        GetPreRequestAction<List<DetectedFace>>()); 
        }

        public static async Task<List<DetectedFace>> DetectFacesWithUrlAsync(object objectToProcess = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{ApiUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", objectToProcess },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        }
                    },
                    { "Parameters",
                        new Dictionary<string, string>()
                        {
                            { "returnRecognitionModel", "true" }
                        }
                    }

                };

            return
                await RequestProcessor
                    .ProcessRequest<object, List<DetectedFace>>(
                        requestDictionary);
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
