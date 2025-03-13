using InterviewSimulation.Core.Models;

namespace InterviewSimulation.Core.Interfaces;

public interface ISpeechRecognizer
{
    Task<RecognizeSpeechResponse> RecognizeSpeech(RecognizeSpeechRequest request);
}