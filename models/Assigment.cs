namespace Discord_Webhook_Clase.models;

/// <summary>
/// Represents an assignment that can be published to Discord.
/// </summary>
public class Assignment
{
    public string Title { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public int Color { get; set; } = 5871434;
}