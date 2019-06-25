using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Services.Models
{
    public interface IFluentApiDefinition
    {
        IFluentEndpoint HasEndpointUri(string endpoint);

    }

    public interface IFluentEndpoint
    {

        IFluentVersionedEndpoint OfVersion(string apiVersion);
    }

    public interface IFluentVersionedEndpoint
    {
        IFluentVersionedEndpoint WithSubscriptionKey(string SubscriptionKey);

        IFluentMethod AndMethod(string method);
    }

    public interface IFluentMethod
    {
        IFluentMethod WithContentType(string ContentType);
        IFluentMethodWithHeaders WithHeaders(Dictionary<string, string> headers);
        TResponse ProcessRequest<TRequest, TResponse>(TRequest request);
    }

    public interface IFluentMethodWithHeaders
    {
        IFluentMethodWithHeaders AndContentType(string ContentType);
        IFluentMethodWithHeaders AndParameters(Dictionary<string, string> headers);
        TResponse ProcessRequest<TRequest, TResponse>();
    }

    public class FluentApiDefinition : IFluentApiDefinition
    {
        Dictionary<string, object> _innerDict = new Dictionary<string, object>();
        EndpointDefinition definition = new EndpointDefinition();
        public FluentApiDefinition(Dictionary<string, object> requestDict = null)
        {
            _innerDict = requestDict ?? new Dictionary<string, object>();
        }
        public IFluentEndpoint HasEndpointUri(string endpointUri)
        {
            definition.EndpointUri = endpointUri;
            return definition;
        }

    }

    public class EndpointDefinition : IFluentEndpoint
    {
        public IFluentVersionedEndpoint OfVersion(string version)
        {
            Version = version;
            return new EndpointWithVersionDefinition(this) { };
        }
        public string EndpointUri { get; set; }
        public string Version { get; set; }
        public string SubscriptionKey { get; set; }

    }

    public class EndpointWithVersionDefinition : IFluentVersionedEndpoint
    {
        FluentApiMethod method;
        public EndpointWithVersionDefinition(EndpointDefinition definition = null)
        {
            Endpoint_Uri = definition.EndpointUri;
            Endpoint_Version = definition.Version;
            Endpoint_SubscriptionKey = definition.SubscriptionKey;
            method = new FluentApiMethod();
        }

        public IFluentMethod WithContentType(string ContentType)
        {
            throw new NotImplementedException();
        }

        public IFluentMethod WithHeaders(Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public IFluentMethod WithParameters(Dictionary<string, string> Parameters)
        {
            throw new NotImplementedException();
        }

        public IFluentMethod AndMethod(string method)
        {
            throw new NotImplementedException();
        }

        public IFluentVersionedEndpoint WithSubscriptionKey(string SubscriptionKey)
        {
            throw new NotImplementedException();
        }

        private string Endpoint_Uri { get; set; }
        private string Endpoint_Version { get; set; }
        private string Endpoint_SubscriptionKey { get; set; }

    }

    public class FluentApiMethod : IFluentMethod
    {
        public TResponse ProcessRequest<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public IFluentMethod WithContentType(string ContentType)
        {
            throw new NotImplementedException();
        }

        public IFluentMethod WithParameters(Dictionary<string, string> Parameters)
        {
            throw new NotImplementedException();
        }

        public IFluentMethodWithHeaders WithHeaders(Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }

    public class MyClass
    {
        void test()
        {
            new FluentApiDefinition()
                .HasEndpointUri("")
                .OfVersion("")
                .WithSubscriptionKey("")
                .AndMethod("")
                .WithContentType("")
                .WithHeaders(default)
                .AndParameters(default)
                .AndContentType(default);
        }
    }
}
