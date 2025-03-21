using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ChatRequest
{   
    [JsonPropertyName("modelUri")]
    public string ModelUri { get; set; }
    [JsonPropertyName("completionOptions")]
    public ChatOptions ChatOptions { get; set; }
    [JsonPropertyName("messages")]
    public List<ChatMessage> Messages { get; set; }
}