using Microsoft.AspNetCore.Mvc;

namespace codecollab_backend.Controllers;

[ApiController]
[Route("/files")]
public class FileController
{
    [HttpGet(Name = "GetFileContent")]
    public string GetFileContent()
    {
        Task<string> fileTask = GetFileContent("/home/rik/Documents/Fontys/semester 6/code/codecollab-backend/codecollab-backend/Controllers/WeatherForecastController.cs");
        string fileContent = fileTask.Result;
        
        return fileContent;
    }

    private async Task<string> GetFileContent(string filePath)
    {
        string fileContent = "";
        
        try
        {
            StreamReader reader = new StreamReader(filePath);
            fileContent = await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return fileContent;
    }
}