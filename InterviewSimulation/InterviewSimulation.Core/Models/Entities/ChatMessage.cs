using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ChatMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}