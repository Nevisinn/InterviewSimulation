namespace InterviewSimulation.Web.Filters;

public static class VacancyFilter
{ 
    public static bool ValidateUrlVacancy(string vacancyLink)
    {   
        const string host = "hh.ru"; //TODO: может стоит рассмотреть иностранные хосты
        var validUrl = Uri.TryCreate(vacancyLink, UriKind.RelativeOrAbsolute, out _);
        if (!validUrl)
            return false;

        var hostData = host.Split(".");
        return hostData.Contains("hh") && hostData.Contains("ru");
    }
    
}