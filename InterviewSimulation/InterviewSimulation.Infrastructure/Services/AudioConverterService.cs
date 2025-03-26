using FFMpegCore;
using FFMpegCore.Pipes;
using Microsoft.AspNetCore.Http;

namespace InterviewSimulation.Infrastructure.Services;

public class AudioConverterService
{
    public static async Task<MemoryStream> ConvertToOggAsync(IFormFile audioFile)
    {
        var inputStream = audioFile.OpenReadStream();
        var outputStream = new MemoryStream();

        await FFMpegArguments
            .FromPipeInput(new StreamPipeSource(inputStream))
            .OutputToPipe(new StreamPipeSink(outputStream), options => options
                    .ForceFormat("opus")  // Используем формат Opus в контейнере Ogg
                    .WithAudioCodec("libopus") // Кодек Opus
                    .WithVariableBitrate(1)  // Регулировка битрейта
            )
            .ProcessAsynchronously();

        outputStream.Position = 0;
        return outputStream;
    }
}