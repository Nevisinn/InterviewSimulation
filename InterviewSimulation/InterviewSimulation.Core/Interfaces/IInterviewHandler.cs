using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Core.Interfaces;

public interface IInterviewHandler
{
    public Task<ChatResponse> StartInterview();
    public Task<ChatResponse> AnalyzeVacancy(AnalyzeVacancyRequest request);
    public Task<ChatResponse> HandleUserAnswer(UserAnswer userAnswer);
    public void FinishInterview();
}