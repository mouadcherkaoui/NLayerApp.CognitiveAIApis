# cognitive-ai-apis


# Fluent ApiCallCommand construction

each api request object is defined through a fluent api that add required headers and parameters, the purpose of this helper is to simplify apis calls 

````csharp  
            var restOperationRequest = (new RestOperationDefinition()
                .WithEndpoint(_endpointUri)
                .WithVersion(_version)
                .WithMethod("POST")
                .WithOperationPath("training")
                .WithOperationSubPath($"projects/{objectToProcess.projectId}/tags")
                .WithSubscriptionKey(_subscriptionKey)
                .WithHeaders(_headers
                    .with("Training-Key", _trainingKey))
                .WithParameters(
                    parameters
                        .InitializeIfNull()
                        .with("name", objectToProcess.tagName))
                .WithContentType("application/json")
                .WithPayload(objectToProcess));

            return await apiRequest
                    .ProcessRequest<object, CreateTagResult>();

   ````
the result of a processed request is wrapped in an object that indicate the operation status and validation results, thus we can have an idea about what happening while calling the API operation. 
````csharp
    public class ResponseWrapper<TResponse>
    {
        public string StatusCode { get; set; }
        public bool IsSuccessfull { get; set; }
        public string ReasonPhrase { get; set; }
        public TResponse ResponseContent { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
````
