using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ReasoningOptions
{
    [JsonPropertyName("mode")]
    public string Mode { get; set; } = "DISABLED";
}