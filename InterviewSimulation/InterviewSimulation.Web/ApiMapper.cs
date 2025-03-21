using InterviewSimulation.Core.Models;

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
    
}