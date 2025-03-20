using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models;

public class ChatAnswer
{
    [JsonPropertyName("alternatives")] 
    public List<Alternatives> Alternatives { get; set; }
    [JsonPropertyName("usage")]
    public ChatUsage Usage { get; set; }
    [JsonPropertyName("modelVersion")]
    public string modelVersion { get; set; }


}