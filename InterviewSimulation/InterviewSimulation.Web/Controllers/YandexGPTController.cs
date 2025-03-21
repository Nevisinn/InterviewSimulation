using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;
using InterviewSimulation.Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSimulation.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YandexGptController : ControllerBase
{
    private IAiChat aiChat;

    public YandexGptController(IAiChat aiChat)
    {
        this.aiChat = aiChat;
    }
    
    [HttpPost]
    public async Task<ActionResult<ChatResponse>> TestYandexGPT(string message)
    {
        var userChatMessage = new ChatMessage
        {
            Role = MessageSenderRoles.User.ToString().ToLower(),
            Text = message
        };
        var response = await aiChat.CommunicateWithAi(userChatMessage, null);
        return Ok(response.Result.Alternatives[0].Message);
    }
}