namespace InterviewSimulation.Core.Models.DTO;

public class AnalyzeVacancyResponse
{
    public string Name { get; set; }
    public string Experience { get; set; }
    public string Description { get; set; }
    public List<string> KeySkills { get; set; }
    public List<string> ProfessionalRoles { get; set; }
}