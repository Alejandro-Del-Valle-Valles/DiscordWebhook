using Discord_Webhook_Clase.models;
using Discord_Webhook_Clase.services;
using DotNetEnv;

try
{
    Env.Load();
    string DISCORD_URL = Env.GetString("DISCORD_URL");


    Assignment assigment = new()
    {
        Title = "Ejemplo de tarea",
        Subject = "Desarrollo Web",
        Description = "Ejemplo de tarea",
        DueDate = new DateTime(2026, 10, 15, 23, 59, 0)
    };

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