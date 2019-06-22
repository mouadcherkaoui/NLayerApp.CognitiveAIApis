# cognitive-ai-apis


# Fluent ApiCallCommand construction

each api request object is defined through a fluent api that add required headers and parameters, the purpose of this helper is to simplify apis calls 

````csharp  
            var apiRequest = (new ApiCallDefinition()
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

   `
