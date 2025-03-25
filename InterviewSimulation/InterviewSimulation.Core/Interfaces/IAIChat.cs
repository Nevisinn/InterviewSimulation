using InterviewSimulation.Core.Models;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Core.Interfaces;

public interface IAiChat
{
    public Task<ChatResponse> CommunicateWithAi(List<ChatMessage> context);
}