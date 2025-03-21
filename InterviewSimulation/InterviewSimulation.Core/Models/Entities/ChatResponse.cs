using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models.Entities;

public class ChatResponse
{
    [JsonPropertyName("result")]
    public ChatAnswer Result { get; set; }
}