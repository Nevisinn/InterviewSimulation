FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InterviewSimulation.Web/InterviewSimulation.Web.csproj", "InterviewSimulation.Web/"]
RUN dotnet restore "InterviewSimulation.Web/InterviewSimulation.Web.csproj"
COPY . .
WORKDIR "/src/InterviewSimulation.Web"
RUN dotnet build "InterviewSimulation.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InterviewSimulation.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterviewSimulation.Web.dll"]
