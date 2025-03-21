using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class Alternatives
{   
    [JsonPropertyName("message")]
    public ChatMessage Message { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}