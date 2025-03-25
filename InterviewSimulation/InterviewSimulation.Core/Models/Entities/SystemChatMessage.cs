using InterviewSimulation.Core.Models.Enums;

namespace InterviewSimulation.Core.Models.Entities;

public class SystemChatMessage : ChatMessage
{
    public SystemChatMessage(string text) : base(text)
    {
        Role = MessageSenderRoles.System.ToString().ToLower();
    }
}