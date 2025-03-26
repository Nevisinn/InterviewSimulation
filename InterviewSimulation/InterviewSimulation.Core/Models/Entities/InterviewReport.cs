using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models.Entities;

public class InterviewReport
{   
    [JsonPropertyName("answer_evaluations")]
    public List<UserAnswerReport> AnswerEvaluations { get; set; }
    [JsonPropertyName("summary")]
    public Summary ReportSummary { get; set; }

    public class Summary
    {   
        [JsonPropertyName("strengths")]
        public List<string> Strengths { get; set; }
        [JsonPropertyName("weaknesses")]
        public List<string> Weaknesses { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
