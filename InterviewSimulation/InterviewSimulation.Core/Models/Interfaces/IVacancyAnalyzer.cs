using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Core.Models.Interfaces;

public interface IVacancyAnalyzer
{
    Task<Vacancy?> AnalyzeVacancy(AnalyzeVacancyRequest request);
}