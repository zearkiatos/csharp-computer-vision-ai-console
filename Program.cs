using System;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Rest.Azure.Authentication;
using ComputerVisionAIConsole.Configuration;

class Program
{
    private static readonly string endpoint = AppConfiguration.azureComputerVisionBaseUrl;
    private static readonly string apiKey = AppConfiguration.azureComputerVisionApiKey;

    static async Task Main(string[] args)
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
        {
            Endpoint = endpoint
        };

        string imageUrl = AppConfiguration.azureBlobStorageImageUrl;
        var imageCaption = await AddImageCaption(client, imageUrl);
        Console.WriteLine($"Caption: {imageCaption}");
    }

    static async Task<string> AddImageCaption(ComputerVisionClient client, string imageUrl)
    {
        var features = new List<VisualFeatureTypes?> { VisualFeatureTypes.Description };

        var response = await client.AnalyzeImageAsync(imageUrl, features);

        if (response.Description.Captions.Count > 0)
        {
            return response.Description.Captions[0].Text;
        }
        else
        {
            return "Caption not generated.";
        }
    }
}
