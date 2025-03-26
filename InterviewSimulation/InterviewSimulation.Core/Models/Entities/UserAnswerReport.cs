using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models.Entities;

public class UserAnswerReport
{   
    [JsonPropertyName("question")]
    public ChatResponse AiQuestion { get; set; }
    [JsonPropertyName("answer")]
    public ChatMessage UserAnswer { get; set; }
    [JsonPropertyName("evaluation")]
    public UserAnswerEvaluation Evaluation { get; set; }
    [JsonPropertyName("total_score")]
    public int TotalScore { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
    
    public class UserAnswerEvaluation
    {   
        [JsonPropertyName("technical_accuracy")]
        public int TechnicalAccuracy;
        [JsonPropertyName("depth")]
        public int Depth;
        [JsonPropertyName("clarity")]
        public int Clarity;
        [JsonPropertyName("examples_quality")]
        public int ExamplesQuality;
        [JsonPropertyName("problem_solving")]
        public int ProblemSolving;
    }
}

