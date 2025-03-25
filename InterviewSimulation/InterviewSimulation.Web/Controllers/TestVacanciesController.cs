using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Models.DTO;
using InterviewSimulation.Infrastructure.Services;
using InterviewSimulation.Web.Filters;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InterviewSimulation.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestVacanciesController : ControllerBase
{
    private IVacancyAnalyzer vacancyAnalyzer;

    public TestVacanciesController(IVacancyAnalyzer vacancyAnalyzer)
    {
        this.vacancyAnalyzer = vacancyAnalyzer;
    }
    
    [HttpPost]
    public async Task<ActionResult<AnalyzeVacancyResponse>> AnalyzeVacancy(string vacancyLink)
    {
        if (!VacancyFilter.ValidateUrlVacancy(vacancyLink))
            return BadRequest("InvalidUrl");

        var request = ApiMapper.Map(vacancyLink);
        var vacancy = await vacancyAnalyzer.AnalyzeVacancy(request);
        if (vacancy is null)
            return BadRequest("Json Serialization Error");
        
        var response = ApiMapper.Map(vacancy);
        
        return Ok(response);
    }
}