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

    string envPath = Path.Combine(AppContext.BaseDirectory, ".env");
    Env.Load(envPath);
    Console.WriteLine(envPath);
    string DISCORD_URL = Env.GetString("DISCORD_URL");
    Console.WriteLine(DISCORD_URL);

    JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true  
    };

    string json = await File.ReadAllTextAsync(args[0]);
    Assignment[]? assigments = JsonSerializer.Deserialize<Assignment[]>(json, jsonOptions);

    if(assigments == null || assigments.Length == 0)
    {
        Console.WriteLine("No hay tareas que añadir.");
        return;
    }

    DiscordWebhookService discord = new(DISCORD_URL);
    int statusCode;
    foreach(Assignment a in assigments) {
        try {
            statusCode = await discord.SendAssigmentAsync(a);
            string response = statusCode == 204
                ? $"La tarea '{a.Title}' se ha enviado con éxito."
                : $"La tarea '{a.Title}' NO se ha podido enviar. Código de estado: {statusCode}";
            Console.WriteLine(response);
        }catch(HttpRequestException ex)
        {
            Console.WriteLine($"Ha ocurrido un error al tratar de enviar la tarea '{a.Title}'. Mensaje del error:\n{ex}");
        }
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Ha ocurrido un error inesperado: {ex}");
}