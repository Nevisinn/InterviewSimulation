using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSimulation.Web.Controllers;

[Route("/api[controller]")]
[Controller]
public class InterviewController : ControllerBase
{
    private readonly IInterviewHandler interviewService;
    private readonly ISpeechRecognizer speechRecognizer;
    

    public InterviewController(IInterviewHandler interviewService, ISpeechRecognizer speechRecognizer)
    {
        this.interviewService = interviewService;
        this.speechRecognizer = speechRecognizer;
    }
    
    [HttpPost("/AnalyzeVacancy")]
    public async Task<ActionResult> AnalyzeVacancy(string vacancyLink)
    {
        if (!VacancyFilter.ValidateUrlVacancy(vacancyLink))
            return BadRequest("InvalidUrl");
        
        var request = ApiMapper.Map(vacancyLink);
        await interviewService.AnalyzeVacancy(request);
        return Ok();
    }
    
    [HttpGet("/StartInterview")]
    public async Task<ActionResult<string>> StartInterview()
    {
        var response = await interviewService.StartInterview();
        return ApiMapper.Map(response);
    }
    
    [HttpGet("/CommunicateWithAi")]
    public async Task<ActionResult<string>> CommunicateWithAi([FromForm] IFormFile? audio)
    {
        if (audio == null || audio.Length == 0)
            return BadRequest("Файл не загружен");

        var request = ApiMapper.Map(audio);
        var recognizeSpeechResponse = await speechRecognizer.RecognizeSpeech(request);
        var userAnswer = ApiMapper.Map(recognizeSpeechResponse);
        var chatResponse = await interviewService.HandleUserAnswer(userAnswer);
        return ApiMapper.Map(chatResponse);
    }
    
    [HttpPost("/FinishInterview")]
    public async Task<ActionResult<string>> FinishInterview()
    {
        throw new NotImplementedException();
    }
    
}