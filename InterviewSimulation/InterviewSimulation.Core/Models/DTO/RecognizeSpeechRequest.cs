namespace InterviewSimulation.Core.Models;

public class RecognizeSpeechRequest
{
    public RecognizeSpeechRequest(byte[] data, string contentType)
    {
        Data = data;
        ContentType = contentType;
    }

    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    
}