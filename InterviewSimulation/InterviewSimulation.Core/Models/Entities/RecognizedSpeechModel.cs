namespace InterviewSimulation.Core.Models.Entities;

public class RecognizedSpeechModel
{
    public string Text { get; set; }

    public RecognizedSpeechModel(string text)
    {
        Text = text;
    }
}