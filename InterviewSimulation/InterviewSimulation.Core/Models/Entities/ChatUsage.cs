using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ChatUsage
{   
    [JsonPropertyName("inputTextTokens")]
    public int InputTextTokens { get; set; }
    [JsonPropertyName("completionTokens")]
    public int CompletionTokens { get; set; }
    [JsonPropertyName("totalTokens")]
    public int TotalTokens { get; set; }
}