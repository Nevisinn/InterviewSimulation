using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;

namespace InterviewSimulation.Infrastructure.Services;

public class YandexSpeechRecognizer : ISpeechRecognizer
{
    private const string url = "https://stt.api.cloud.yandex.net/speech/v1/stt:recognize";
    public async Task<RecognizeSpeechResponse> RecognizeSpeech(RecognizeSpeechRequest request)
    {
        using var client = new HttpClient();
        using var yandexRequest = new HttpRequestMessage(HttpMethod.Post, url);

        yandexRequest.Headers.Add("Authorization", $"Api-Key {EnvironmentVars.YandexApiKey}");

        using var content = new ByteArrayContent(request.Data);
        content.Headers.Add("Content-Type", "audio/ogg");
        yandexRequest.Content = content;
        var response = await client.SendAsync(yandexRequest);

        var result = await response.Content.ReadAsStringAsync();
        
        return new RecognizeSpeechResponse(result);
    }
}