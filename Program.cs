using System.Text.Json;
using Discord_Webhook_Clase.models;
using Discord_Webhook_Clase.services;
using DotNetEnv;

try
{

    if(args.Length != 1)
    {
        Console.WriteLine("Proporciona la ruta del JSON");
        return;
    }
    if(!File.Exists(args[0]))
    {
        Console.WriteLine($"El fichero '{args[0]}' no existe o no se ha encontrado.");
        return;
    }

    Env.Load();
    string DISCORD_URL = Env.GetString("DISCORD_URL");

    JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true  
    };

    string json = await File.ReadAllTextAsync(args[0]);
    Assignment? assigment = JsonSerializer.Deserialize<Assignment>(json, jsonOptions);

    if(assigment == null)
    {
        Console.WriteLine("La tarea está vacía, no se puede crear");
        return;
    }

    DiscordWebhookService discord = new(DISCORD_URL);
    int statusCode = await discord.SendAssigmentAsync(assigment);
    string response = statusCode == 204
        ? "La tarea se ha enviado con éxito."
        : $"La tarea NO se ha podido enviar. Código de estado: {statusCode}";
        Console.WriteLine(response);
}
catch(HttpRequestException ex)
{
    Console.WriteLine($"Ha ocurrido un error al tratar de enviar la tarea: {ex}");
}
catch(Exception ex)
{
    Console.WriteLine($"Ha ocurrido un error inesperado: {ex}");
}