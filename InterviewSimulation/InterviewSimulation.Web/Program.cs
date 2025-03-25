using InterviewSimulation.Core.Interfaces;
using InterviewSimulation.Core.Services;
using InterviewSimulation.Infrastructure.Services;
using InterviewSimulation.Web.Controllers;
using InterviewSimulation.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IAiChat, YandexGptApi>();
builder.Services.AddScoped<ISpeechRecognizer, YandexSpeechRecognizer>();
builder.Services.AddScoped<IInterviewHandler, InterviewService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddScoped<IVacancyAnalyzer, HhVacancyAnalyzer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets();
app.MapControllers();
app.UseRouting();

app.UseWebSockets();
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();


