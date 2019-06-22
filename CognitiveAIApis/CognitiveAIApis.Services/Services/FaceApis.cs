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
using System.Linq;
using CognitiveAIApis.Services.Models;
using System.Security;

namespace CognitiveAIApis.Services
{
    public class FaceApis
    {

        private readonly string _endpointUri;
        private readonly string _version;
        private readonly string _subscriptionKey;

        public FaceApis(string endpointUri, string version, string subscriptionKey)
        {
            _endpointUri = $"{endpointUri}/face";
            _version = version;
            _subscriptionKey = subscriptionKey;
        }

        public FaceApis(ApiCredential credential): this(credential.Endpoint, credential.Version, credential.SubscriptionKey)
        {

        }
        public async Task<object> DetectFacesAsync(object objectToProcess, Dictionary<string, string> parameters = null)
        {
            using (FileStream fileStream = new FileStream(((dynamic)objectToProcess).imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                var bytes = binaryReader.ReadBytes((int)fileStream.Length);

                var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", bytes },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
                            { "ContentType", "application/octet-stream" },
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

                return await RequestProcessor
                        .ProcessRequest<byte[], List<DetectedFace>>(
                            requestDictionary); 
            }
        }
        public async Task<object> DetectFacesFromUrlAsync(object objectToProcess, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", objectToProcess },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
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
                    .ProcessRequest<object, List<DetectedFace>>(
                        requestDictionary); 
        }

        public async Task<List<DetectedFace>> DetectFacesWithUrlAsync(object objectToProcess, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", objectToProcess },
                    { "RequestPath", "detect" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
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

    }
}
