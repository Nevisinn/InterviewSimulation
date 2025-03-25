using InterviewSimulation.Core.Models.Enums;

namespace InterviewSimulation.Core.Models.Entities;

public class Interview
{
    public User User { get; set; }
    public Vacancy Vacancy { get; set; }
    public List<ChatMessage> Context { get; set; }
    public List<ChatMessage> UserAnswer { get; set; }
    public List<ChatResponse> AiQuestions { get; set; }
    public InterviewStatus Status { get; set; }

    public Interview(User user)
    {
        User = user;
        Context = [];
        UserAnswer = [];
        AiQuestions = [];
    }
}