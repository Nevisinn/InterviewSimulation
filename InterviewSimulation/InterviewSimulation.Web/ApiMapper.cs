using InterviewSimulation.Core.Models;
using System.Text.RegularExpressions;
using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Web;

public static class ApiMapper
{
    public static RecognizeSpeechRequest Map(IFormFile audio)
    {
        var bytes = new byte[audio.Length];
        using var fileStream = audio.OpenReadStream();
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        return new RecognizeSpeechRequest(bytes, audio.ContentType);
    }
    
    public static AnalyzeVacancyRequest Map(string vacancyLink) => new(vacancyLink);

    public static AnalyzeVacancyResponse Map(Vacancy vacancy) => new()
    {
        Name = vacancy.Name,
        Experience = vacancy.Experience.Name,
        Description = Regex.Replace(vacancy.Description, "<.*?>", String.Empty),
        KeySkills = vacancy.KeySkills.Select(k=>k.Name).ToList(),
        ProfessionalRoles = vacancy.ProfessionalRoles.Select(r=>r.Name).ToList()
    };

    public static string Map(ChatResponse response)
    {
        var chatResponseMap = response.Result.Alternatives.FirstOrDefault()?.Message.Text;
        return chatResponseMap ?? "Нет сообщений";
    }

    public static UserAnswer Map(RecognizeSpeechResponse response) => new(response.Text);
    
    
}