using CognitiveAIApis.Services.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Services.Models
{
    public interface IApiDictionary: IDictionary<string, object>
    {
        IApiDictionary WithEndpoint(string endpoint, string version);
        IApiDictionary WithEndpoint(string endpoint);
        IApiDictionary WithSubscriptionKey(string SubscriptionKey);
        IApiDictionary WithContentType(string ContentType);
        IApiDictionary WithParameters(Dictionary<string, string> Parameters);
    }
    public class ApiDictionary : Dictionary<string, object>, IApiDictionary
    {
        public IApiDictionary WithSubscriptionKey(string SubscriptionKey)
        {
            this.Add(nameof(SubscriptionKey), SubscriptionKey);
            return this;
        }

        public IApiDictionary WithContentType(string ContentType)
        {
            this.Add(nameof(ContentType), ContentType);
            return this;
        }

        public IApiDictionary WithParameters(Dictionary<string, string> Parameters)
        {
            this.Add(nameof(Parameters), Parameters);
            return this;
        }
        public IApiDictionary WithParameters(string key, string value)
        {
            this.Add(nameof(Parameters), Parameters.with(key, value));
            return this;
        }

        public IApiDictionary WithEndpoint(string Endpoint, string Version)
        {
            this.Add(nameof(Endpoint_Uri), Endpoint);
            this.Add(nameof(Endpoint_Version), Version);
            return this;
        }

        public IApiDictionary WithEndpoint(string Endpoint)
        {
            this.Add(nameof(Endpoint), Endpoint);
            return this;
        }

        public string Endpoint_Uri { get => (string)this[nameof(Endpoint_Uri)]; }
        public string Endpoint_Version { get => (string)this[nameof(Endpoint_Version)]; }
        public string Operation_Method { get => (string)this[nameof(Operation_Method)]; }
        public string Operation_Path { get => (string)this[nameof(Operation_Path)]; }
        public string Operation_SubPath { get => (string)this[nameof(Operation_SubPath)]; }
        public Dictionary<string, string> Headers { get => (Dictionary<string, string>)this[nameof(Headers)]; }
        public Dictionary<string, string> Parameters { get => (Dictionary<string, string>)this[nameof(Parameters)]; }
    }
}
