using System.Net.WebSockets;
using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSimulation.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestSpeechRecognizerController : ControllerBase
{
    private ISpeechRecognizer speechRecognizer;

    public TestSpeechRecognizerController(ISpeechRecognizer speechRecognizer)
    {
        this.speechRecognizer = speechRecognizer;
    }

    [HttpPost]
    public async Task<ActionResult<RecognizeSpeechResponse>> RecognizeSpeech([FromForm] IFormFile? audio)
    {
        if (audio == null || audio.Length == 0)
            return BadRequest("Файл не загружен");

        var request = ApiMapper.Map(audio);
        var response = await speechRecognizer.RecognizeSpeech(request);
        return response;
    }
}