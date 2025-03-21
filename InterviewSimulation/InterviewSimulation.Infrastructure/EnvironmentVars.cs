namespace InterviewSimulation.Infrastructure;

public static class EnvironmentVars
{
    public static string YandexApiKey = Environment.GetEnvironmentVariable("YandexAPIKey") ??
    public static string YandexCatalogId = Environment.GetEnvironmentVariable("YandexCatalogId") ?? 

    public static string AccessTokenHhRu => Environment.GetEnvironmentVariable("ACCESS_TOKEN_HHRU") ??

    public static string Email => Environment.GetEnvironmentVariable("EMAIL") ??
}