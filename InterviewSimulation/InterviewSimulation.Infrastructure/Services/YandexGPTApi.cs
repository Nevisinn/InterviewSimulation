using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Infrastructure.Services;

public class YandexGptApi : IAiChat
{
    private static HttpClient httpClient = new();
    private const string completion = "https://llm.api.cloud.yandex.net/foundationModels/v1/completion";
    private readonly string modelUri = $"gpt://{EnvironmentVars.YandexCatalogId}/yandexgpt/rc";
    
    public async Task<ChatResponse> CommunicateWithAi(ChatMessage userMessage, ChatMessage? adminMessage)
    {
        using HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, completion);

        var request = new ChatRequest
        {
            ModelUri = modelUri,
            ChatOptions = new ChatOptions(),
            Messages = [userMessage]
        };
        
        if (adminMessage is not null)
            request.Messages.Add(adminMessage);

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        httpRequestMessage.Headers.Add("Authorization", $"Api-Key {EnvironmentVars.YandexApiKey}");
        httpRequestMessage.Content = content;
        var response = await httpClient.SendAsync(httpRequestMessage);
        var chatResponse = await response.Content.ReadFromJsonAsync<ChatResponse>();

        return chatResponse;
    }
}