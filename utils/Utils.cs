namespace Discord_Webhook_Clase.utils;

public static class Utils
{
    public static long ToUnixTimestamp(DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
    
}