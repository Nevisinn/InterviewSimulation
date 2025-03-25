using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;
using InterviewSimulation.Core.Models.Entities;
using InterviewSimulation.Core.Models.Enums;
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
    
    /*[HttpPost]
    public async Task<ActionResult<ChatResponse>> TestYandexGPT(string message)
    {
        var userChatMessage = new ChatMessage(MessageSenderRoles.User.ToString().ToLower(), message);
        var response = await aiChat.CommunicateWithAi();
        return Ok(response.Result.Alternatives[0].Message);
    }*/
}
