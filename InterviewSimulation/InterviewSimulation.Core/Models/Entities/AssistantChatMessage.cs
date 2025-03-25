using InterviewSimulation.Core.Models.Enums;

namespace InterviewSimulation.Core.Models.Entities;

public class AssistantChatMessage : ChatMessage
{
    public AssistantChatMessage(string text) : base(text)
    {
        Role = MessageSenderRoles.Assistant.ToString().ToLower();
    }
}