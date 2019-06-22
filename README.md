# cognitive-ai-apis


# Fluent ApiCallCommand construction

each api request object is defined through a fluent api that add required headers and parameters, the purpose of this helper is to simplify apis calls 

````csharp  
     var requestDict = new ApiDefinition()
                .WithEndpoint(_endpointUri)
                .WithVersion(_version)
                .WithMethod("POST")
                .WithOperationPath("training")
                .WithOperationSubPath("projects")
                .WithSubscriptionKey(_subscriptionKey)
                .WithHeaders(_headers
                    .with("Training-Key", _trainingKey))
                .WithParameters(
                    parameters
                        .InitializeIfNull()
                        .with("name", "testProject"))
                .WithContentType("application/json")
                .WithPayload(objectToProcess);

            requestDict.ProcessRequest<object, CreateProjectResult>(); 
   `
