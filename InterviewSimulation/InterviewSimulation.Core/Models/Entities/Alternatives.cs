using System.Text.Json.Serialization;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Core.Models;

public class Alternatives
{   
    [JsonPropertyName("message")]
    public AssistantChatMessage Message { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}