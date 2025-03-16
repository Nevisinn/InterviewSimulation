using System.Text.RegularExpressions;
using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Web;

public static class ApiMapper
{
    public static AnalyzeVacancyRequest Map(string vacancyLink) => new(vacancyLink);

    public static AnalyzeVacancyResponse Map(Vacancy vacancy) => new()
    {
        Name = vacancy.Name,
        Experience = vacancy.Experience.Name,
        Description = Regex.Replace(vacancy.Description, "<.*?>", String.Empty),
        KeySkills = vacancy.KeySkills.Select(k=>k.Name).ToList(),
        ProfessionalRoles = vacancy.ProfessionalRoles.Select(r=>r.Name).ToList()
    };


}