using CognitiveAIApis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using CognitiveAIApis.Infrastructure;

namespace CognitiveAIApis.Services
{
    public class ComputerVisionApis
    {
        private const string ApiUri = "https://westus.api.cognitive.microsoft.com";
        private const string SubscriptionKey = "8cf15696a50e46d6b5c8b8d14fabeec6";
        private const string Version = "v2.0";
        private const string imageFilePath = "Images/image.jpg";
        public static async Task<object> AnalyzeImage(object objectToProcess = null)
        {
            using (FileStream fileStream = new FileStream(((dynamic)objectToProcess).imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                var bytes = binaryReader.ReadBytes((int)fileStream.Length);

                var request = new ApiRequest<byte[]>()
                {
                    BaseAddress = $"{ApiUri}/vision",
                    SubscriptionKey = SubscriptionKey,
                    Method = new HttpMethod("POST"),
                    Path = "",
                    Service = "analyze",
                    Version = Version,
                    Request = bytes,
                    Headers = new Dictionary<string, string>()
                            {
                                { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                                { "ContentType", "application/octet-stream" },
                                { "Accept", "application/json" }
                            },
                    QueryParameters = new Dictionary<string, string>()
                    {
                        { "returnRecognitionModel", "true" }
                    }
                };

                return await RequestProcessor.ProcessRequest<byte[], object>(request);
            }
        }
        public static async Task<object> AnalyzeImageWithUrl(object objectToProcess = null)
        {
            var request = new ApiRequest<object>()
            {
                BaseAddress = $"{ApiUri}/vision",
                SubscriptionKey = SubscriptionKey,
                Method = new HttpMethod("POST"),
                Path = "",
                Service = "analyze",
                Version = Version,
                Request = objectToProcess,
                Headers = new Dictionary<string, string>()
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        },
                QueryParameters = new Dictionary<string, string>()
                {
                    { "returnRecognitionModel", "true" },
                    { "details", "Celebrities" }
                }
            };

            return await RequestProcessor.ProcessRequest<object, object>(request);
        }

        public static async Task<object> DescribeImage(object objectToProcess = null)
        {
            using (FileStream fileStream = new FileStream(((dynamic)objectToProcess).imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                var bytes = binaryReader.ReadBytes((int)fileStream.Length);

                var request = new ApiRequest<byte[]>()
                {
                    BaseAddress = $"{ApiUri}/vision",
                    SubscriptionKey = SubscriptionKey,
                    Method = new HttpMethod("POST"),
                    Path = "",
                    Service = "describe",
                    Version = Version,
                    Request = bytes,
                    Headers = new Dictionary<string, string>()
                            {
                                { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                                { "ContentType", "application/octet-stream" },
                                { "Accept", "application/json" }
                            }
                };

                return await RequestProcessor.ProcessRequest<byte[], object>(request);
            }
        }
        public static async Task<object> DescribeImageWithUrl(object objectToProcess = null)
        {
            var request = new ApiCallCommand<object, ImageAnalysis>(objectToProcess)
            {
                Endpoint_Uri = $"{ApiUri}/vision",
                SubscriptionKey = SubscriptionKey,
                Operation_Method = "POST",
                Operation_Path = "describe",
                Endpoint_Version = Version,
                Headers = new Dictionary<string, string>()
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        }
            };

            var postRequestAction = new Func<object, HttpRequestMessage>((o) =>
            {
                var json = JsonConvert.SerializeObject(o);
                var byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            });

            var preRequestAction = new Func<HttpResponseMessage, ImageAnalysis>((response) =>
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                var resultToReturn = JsonConvert.DeserializeObject<ImageAnalysis>(jsonContent);
                return resultToReturn;
            });
            return await RequestProcessor.ProcessRequest(request, preRequestAction, postRequestAction);
        }

        public static async Task<object> DetectObjectsWithUrl(object objectToProcess = null)
        {
            var request = new ApiCallCommand<object, DetectResult>(objectToProcess)
            {
                Endpoint_Uri = $"{ApiUri}/vision",
                SubscriptionKey = SubscriptionKey,
                Operation_Method = "POST",
                Operation_Path = "detect",
                Endpoint_Version = Version,
                Headers = new Dictionary<string, string>()
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        }
            };

            var postRequestAction = new Func<object, HttpRequestMessage>((o) =>
            {
                var json = JsonConvert.SerializeObject(o);
                var byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            });

            var preRequestAction = new Func<HttpResponseMessage, DetectResult>((response) =>
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                var resultToReturn = JsonConvert.DeserializeObject<DetectResult>(jsonContent);
                return resultToReturn;
            });
            return await RequestProcessor.ProcessRequest<object, DetectResult>(request, preRequestAction, postRequestAction);
        }

        public static async Task<object> GetAreaOfInterestWithUrl(object objectToProcess = null)
        {
            var request = new ApiCallCommand<object, AreaOfInterestResult>(objectToProcess)
            {
                Endpoint_Uri = $"{ApiUri}/vision",
                SubscriptionKey = SubscriptionKey,
                Operation_Method = "POST",
                Operation_Path = "areaOfInterest",
                Endpoint_Version = Version,
                Headers = new Dictionary<string, string>()
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        }
            };

            var postRequestAction = new Func<object, HttpRequestMessage>((o) =>
            {
                var json = JsonConvert.SerializeObject(o);
                var byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            });

            var preRequestAction = new Func<HttpResponseMessage, AreaOfInterestResult>((response) =>
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                var resultToReturn = JsonConvert.DeserializeObject<AreaOfInterestResult>(jsonContent);
                return resultToReturn;
            });
            return await RequestProcessor.ProcessRequest<object, AreaOfInterestResult>(request, preRequestAction, postRequestAction);
        }

        public static async Task<object> RecognizeTextWithUrl(object objectToProcess = null)
        {
            var request = new ApiCallCommand<object, TextRecognitionResult>(objectToProcess)
            {
                Endpoint_Uri = $"{ApiUri}/vision",
                SubscriptionKey = SubscriptionKey,
                Operation_Method = "POST",
                Operation_Path = "recognizeText",
                Endpoint_Version = Version,
                Headers = new Dictionary<string, string>()
                        {
                            { "Ocp-Apim-Subscription-Key", SubscriptionKey },
                            { "ContentType", "application/json" },
                            { "Accept", "application/json" }
                        },
                Parameters = new Dictionary<string, string>()
                {
                    { "mode", "Printed" }
                }
            };

            var postRequestAction = new Func<object, HttpRequestMessage>((o) =>
            {
                var json = JsonConvert.SerializeObject(o);
                var byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                var requestMessage = new HttpRequestMessage() { Content = byteArrayContent };

                return requestMessage;
            });

            var preRequestAction = new Func<HttpResponseMessage, TextRecognitionResult>((response) =>
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                var resultToReturn = JsonConvert.DeserializeObject<TextRecognitionResult>(jsonContent);
                return resultToReturn;
            });

            return await RequestProcessor.ProcessRequest<object, TextRecognitionResult>(request, preRequestAction, postRequestAction);
        }

    }
}
