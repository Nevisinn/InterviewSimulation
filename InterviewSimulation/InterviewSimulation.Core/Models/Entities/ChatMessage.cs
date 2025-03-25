using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models.Entities;

public abstract class ChatMessage
{
    protected ChatMessage(string text)
    {
        Text = text;
    }

    [JsonPropertyName("role")]
    public string Role { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}