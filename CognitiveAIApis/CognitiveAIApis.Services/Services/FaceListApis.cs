using CognitiveAIApis.Models;
using CognitiveAIApis.Services.Models;
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
    public class FaceListApis
    {
        private readonly string _endpointUri;
        private readonly string _subscriptionKey;
        private readonly string _version;

        public FaceListApis(string endpointUri, string version, string subscriptionKey)
        {
            _endpointUri = endpointUri;
            _version = version;
            _subscriptionKey = subscriptionKey;
        }

        public FaceListApis(ApiCredential credential) : this(credential.Endpoint, credential.Version, credential.SubscriptionKey)
        {

        }
        public async Task<FaceList> CreateFaceListAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "PUT" },
                    { "RequestObject", objectToProcess },
                    { "RequestSubPath",$"{objectToProcess.FaceListId}" },
                    { "RequestPath", "facelists" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
                            { "ContentType", "application/octet-stream" },
                            { "Accept", "application/json" }
                        }
                    }

                };

            return
                await RequestProcessor
                    .ProcessRequest<object, FaceList>(
                        requestDictionary);
        }

        public async Task<object> DeleteFaceListAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "DELETE" },
                    { "RequestObject", objectToProcess },
                    { "RequestSubPath",$"{objectToProcess.faceListId}" },
                    { "RequestPath", "facelists" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
                            { "ContentType", "application/octet-stream" },
                            { "Accept", "application/json" }
                        }
                    }
                };

            return
                await RequestProcessor
                    .ProcessRequest<object, object>(
                        requestDictionary);
        }    

    public async Task<object> AddFaceAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            using (FileStream fileStream = new FileStream(objectToProcess.imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                var bytes = binaryReader.ReadBytes((int)fileStream.Length);

                var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", bytes },
                    { "RequestSubPath",$"{objectToProcess.faceListId}/persistedFaces" },
                    { "RequestPath", "facelists" },
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
                            { "detectionModel", objectToProcess.detectionModel },
                            { "targetFace", objectToProcess.targetFace }
                        }
                    }
                };

                return
                    await RequestProcessor
                        .ProcessRequest<object, object>(
                            requestDictionary);
            }
        }

        public async Task<object> AddFaceWithUrlAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "POST" },
                    { "RequestObject", objectToProcess },
                    { "RequestSubPath",$"{objectToProcess.faceListId}/persistedFaces" },
                    { "RequestPath", "facelists" },
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
                            { "targetFace", objectToProcess.targetFace }
                        }
                    }
                };

            return
                await RequestProcessor
                    .ProcessRequest<object, object>(
                        requestDictionary);
        }

        public async Task<object> GetFaceListAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "GET" },
                    { "RequestObject", objectToProcess },
                    { "RequestSubPath",$"{objectToProcess.faceListId}" },
                    { "RequestPath", "facelists" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
                            { "ContentType", "application/octet-stream" },
                            { "Accept", "application/json" }
                        }
                    }

                };

            return
                await RequestProcessor
                    .ProcessRequest<object, FaceList>(
                        requestDictionary);
        }

        public async Task<object> ListFaceListsAsync(dynamic objectToProcess = null, Dictionary<string, string> parameters = null)
        {
            var requestDictionary = new Dictionary<string, object>()
                {
                    { "EndpointUri", $"{_endpointUri}/face" },
                    { "Version", "v1.0" },
                    { "Method", "GET" },
                    { "RequestObject", objectToProcess },
                    { "RequestSubPath","" },
                    { "RequestPath", "facelists" },
                    { "Headers",
                        new Dictionary<string, string>
                        {
                            { "Ocp-Apim-Subscription-Key", _subscriptionKey },
                            { "ContentType", "application/octet-stream" },
                            { "Accept", "application/json" }
                        }
                    }

                };

            return
                await RequestProcessor
                    .ProcessRequest<object, object>(
                        requestDictionary);
        }
    }
}
