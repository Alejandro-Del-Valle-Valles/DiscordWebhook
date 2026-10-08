namespace Discord_Webhook_Clase.models;

/// <summary>
/// Represents an assignment that can be published to Discord.
/// </summary>
public class Assignment
{
    required public string Title { get; set; }

    public string Subject { get; set; } = string.Empty;

    public string Description { get; set; } = "Sin Descripción";

    /// <summary>
    /// Format yyyy-MM-ddTHH:mm:ss
    /// </summary>
    public DateTime DueDate { get; set; }
    public string Url { get; set; } = "Sin Enlace";

    /// <summary>
    /// Hexadecimal code color. Default green
    /// </summary>
    public string Color { get; set; } = "6CD667";

}