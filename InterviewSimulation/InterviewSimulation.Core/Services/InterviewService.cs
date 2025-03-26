using System.Text.Json;
using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;
using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;
using InterviewSimulation.Core.Models.Enums;
using InterviewSimulation.Core.Models.Prompts;

namespace InterviewSimulation.Core.Services;

public class InterviewService : IInterviewHandler
{
    private Interview interview;
    private IVacancyAnalyzer vacancyAnalyzer;
    private IAiChat aiChat;

    public InterviewService(IVacancyAnalyzer vacancyAnalyzer,IAiChat aiChat)
    {
        this.vacancyAnalyzer = vacancyAnalyzer;
        this.aiChat = aiChat;
    }
    
    
    public async Task<ChatResponse> StartInterview()
    {
        interview.Status = InterviewStatus.Active;
        var userMessage = new UserChatMessage("Начать интервью");
        interview.Context.Add(userMessage);
        var response = await aiChat.CommunicateWithAi(interview.Context);
        return response;
    }

    public async Task<ChatResponse> AnalyzeVacancy(AnalyzeVacancyRequest request)
    {
        var vacancy = await vacancyAnalyzer.AnalyzeVacancy(request);
        interview.Vacancy = vacancy;
        var prompt = new AnalyzeVacancyPrompt(vacancy.Name, vacancy.Experience.Name, vacancy.Description, string.Join(",",vacancy.KeySkills));
        var systemMessage = new SystemChatMessage(prompt.Text);
        interview.Context.Add(systemMessage);
        var response = await aiChat.CommunicateWithAi(interview.Context);
        var text = response.Result.Alternatives.FirstOrDefault()?.Message.Text;
        if (text == "Должность не относится к IT")
            throw new ArgumentException(text);
        
        interview.AiQuestions.Add(response);
        return response;
    }

    public async Task<ChatResponse> HandleUserAnswer(UserAnswer userAnswer)
    {
        var userMessage = new UserChatMessage(userAnswer.Text);
        interview.Context.Add(userMessage);
        interview.UserAnswer.Add(userMessage);
        var response = await aiChat.CommunicateWithAi(interview.Context);
        return response;
    }

    public async Task<InterviewReport> FinishInterview()
    {
        var reportPrompt = new InterviewReportPrompt();
        var systemMessage = new SystemChatMessage(reportPrompt.Text);
        var userMessage = new UserChatMessage("Проведи анализ ответов");
        interview.Context.Add(systemMessage);
        interview.Context.Add(userMessage);
        var response = await aiChat.CommunicateWithAi(interview.Context);
        var aiChatMessage = response.Result.Alternatives.FirstOrDefault()?.Message.Text;
        var interviewRepost = JsonSerializer.Deserialize<InterviewReport>(aiChatMessage);
        interview.Status = InterviewStatus.Done;
        return interviewRepost;
    }
}