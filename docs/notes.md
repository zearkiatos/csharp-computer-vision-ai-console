# Azure Computer vision documentation

## Requirements dependencies


```sh
$ dotnet add package Microsoft.Azure.CognitiveServices.Vision.ComputerVision

# Authentication package

$ dotnet add package Microsoft.Rest.ClientRuntime.Azure.Authentication
```

## Testing the computer vision from postman 👩🏻‍🚀

```sh
# Placeholder endpoint

$ https://<your-endpoint>.cognitiveservices.azure.com/vision/v3.2/analyze?visualFeatures=Description
```

## This is the request placeholder

```json
{
    "url": "<IMAGE_URL>"
}
```