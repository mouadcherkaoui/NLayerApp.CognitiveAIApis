using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Rest;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using CognitiveAIApis.Services;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using CognitiveAIApis.Infrastructure;
using static CognitiveAIApis.Services.CustomVisionApis;
using CognitiveAIApis.Models.CustomVision;
using CognitiveAIApis.Services.Models;

namespace CognitiveAIApis.Services
{
    class Program
    {
        private const string subscriptionKey = "**********************";

        private const string _endpoint =
            "https://westus2.api.cognitive.microsoft.com";

        static void Main(string[] args)
        {
            var credential = new ApiCredential { Endpoint = _endpoint, Version = "v3.0", SubscriptionKey = subscriptionKey };
            var visionApis = new CustomVisionApis(credential, trainingKey: "************************");
            var result = visionApis.CreateProjectAsync(new { name = "testProject"}).Result;
            dynamic tagResult0 = visionApis.CreateTagAsync(new { projectId = result.id, tagName = "fork" }).Result;
            dynamic tagResult1 = visionApis.CreateTagAsync(new { projectId = result.id, tagName = "scissor" }).Result;

            var requestObject = new CreateImagesRequest()
            {
                images = new List<ImageUrl>
                {
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_1.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_2.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_3.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_4.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_5.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_6.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_7.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_8.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_9.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_10.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/fork/fork_11.jpg?raw=true",
                        tagIds = new List<string>{ tagResult0.id }
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_1.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_2.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_3.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_4.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_5.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_6.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_7.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_8.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_9.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_10.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    },
                    new ImageUrl
                    {
                        url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_11.jpg?raw=true",
                        tagIds = new List<string>{ tagResult1.id}
                    }
                }
            };
            var createImagesResult = visionApis.CreateImagesFromUrlsAsync(new { projectId = result.id, images = requestObject.images, tagName = "testag" }).Result;
            var trainingResult = visionApis.TrainProjectAsync(new { projectId = result.id }).Result;
            var iterations = visionApis.GetIterations(new { projectId = result.id }).Result;
            var updateIterationResult = visionApis.UpdateIteration(new { projectId = result.id, iterationId = iterations[0].id, iteration = new { isDefault=true } }).Result;
            var quicktest = visionApis.QuickTestImageWithUrlAsync(iterations[0].id, result.id, new { url = "https://github.com/Azure/LearnAI-Bootcamp/blob/master/lab01.3_customvision02/Resources/Starter/CustomVision.Sample/Images/scissors/scissors_15.jpg?raw=true" }).Result;
        }
    }
}
