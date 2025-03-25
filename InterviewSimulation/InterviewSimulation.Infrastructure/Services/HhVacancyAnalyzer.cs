using System.Net.Http.Json;
using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Core.Models.Entities;

namespace InterviewSimulation.Infrastructure.Services;

public class HhVacancyAnalyzer : IVacancyAnalyzer
{
    private static readonly HttpClient httpClient = new();
    public async Task<Vacancy?> AnalyzeVacancy(AnalyzeVacancyRequest request)
    {   
        var vacancyId = GetVacancyId(request.VacancyLink);
        var url = $"https://api.hh.ru/vacancies/{vacancyId}";
        var getVacancyRequest = new HttpRequestMessage(HttpMethod.Get, url);
        getVacancyRequest.Headers.Add("User-Agent",$"InterviewSimulation/1.0 ({EnvironmentVars.Email})");
        getVacancyRequest.Headers.Add("Authorization", $"Bearer {EnvironmentVars.AccessTokenHhRu}");
        var response = await httpClient.SendAsync(getVacancyRequest);
        var vacancy = await response.Content.ReadFromJsonAsync<Vacancy>();
        return vacancy;
    }

    private static string GetVacancyId(string vacancyLink)
    {
        var uri = new Uri(vacancyLink);
        var id = uri.LocalPath.Split("/")[2];
        return id;
    }
    
}