namespace InterviewSimulation.Core.Models;

public class RecognizeSpeechResponse
{
    public string Text { get; set; }

    public RecognizeSpeechResponse(string text)
    {
        Text = text;
    }
}