using Discord_Webhook_Clase.models;
using System.Net.Http.Json;
using Discord_Webhook_Clase.utils;

namespace Discord_Webhook_Clase.services;

public class DiscordWebhookService
{
    public string WebhookURL {get; set;}

    public DiscordWebhookService(string webhookUrl)
    {
        WebhookURL = webhookUrl;
    }
    
    public async void SendAssigmentAsync(Assignment assigment)
    {
        using HttpClient httpClient = new();
        long unixTimestamp = Utils.ToUnixTimestamp(assigment.DueDate);

        var payload = new
        {
            embeds = new[]
            {
                new
                {
                    title = assigment.Title,
                    description = assigment.Description,
                    color = assigment.Color,
                    fields = new[]
                    {
                        new
                        {
                            name = "Asignatura",
                            value = assigment.Subject,
                            inline = true
                        },
                        new
                        {
                            name = "Fecha límite:",
                            value = $"<t:{unixTimestamp}:F>\n⏳ <t:{unixTimestamp}:R>",
                            inline = true
                        }
                    }
                }
            }
        };

        HttpResponseMessage response = await httpClient.PostAsJsonAsync(
            WebhookURL,
            payload
        );

        response.EnsureSuccessStatusCode();
    }
}