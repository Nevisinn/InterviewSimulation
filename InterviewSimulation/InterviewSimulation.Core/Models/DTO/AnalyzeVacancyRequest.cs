namespace InterviewSimulation.Core.Models.DTO;

public class AnalyzeVacancyRequest
{
    public AnalyzeVacancyRequest(string vacancyLink)
    {
        VacancyLink = vacancyLink;
    }

    public string VacancyLink { get; }
}