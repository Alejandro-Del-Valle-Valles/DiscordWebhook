using Discord_Webhook_Clase.models;
using Discord_Webhook_Clase.services;

const string DISCORD_URL = "";


Assignment assigment = new()
{
    Title = "Ejemplo de tarea",
    Subject = "Desarrollo Web",
    Description = "Crear una aplicación CRUD utilizando ASP.NET Core.",
    DueDate = new DateTime(2026, 10, 15, 23, 59, 0)
};

DiscordWebhookService discord = new(DISCORD_URL);
discord.SendAssigmentAsync(assigment);