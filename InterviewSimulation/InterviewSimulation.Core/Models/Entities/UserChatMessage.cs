using InterviewSimulation.Core.Models.Enums;

namespace InterviewSimulation.Core.Models.Entities;

public class UserChatMessage : ChatMessage
{
    public UserChatMessage(string text) : base(text)
    {
        Role = MessageSenderRoles.User.ToString().ToLower();
    }
}