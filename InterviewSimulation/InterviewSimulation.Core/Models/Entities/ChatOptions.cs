using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ChatOptions
{   
    
    [JsonPropertyName("temperature")] [Range(0.3, 1.0)] 
    public double Temperature { get; set; } = 0.3;
    [JsonPropertyName("stream")]
    public bool Stream { get; set; } = false;
    [JsonPropertyName("maxTokens")]
    public int MaxTokens { get; set; } = 2000;
    [JsonPropertyName("reasoningOptions")]
    public ReasoningOptions ReasoningOptions { get; set; } = new();
}