using System;
using System.Text.Json;

public class ResponseParser
{
    public static string ExtractText(string jsonResponse)
    {
        try
        {
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                var root = doc.RootElement;

                if (root.TryGetProperty("candidates", out JsonElement candidates) &&
                    candidates.GetArrayLength() > 0)
                {
                    var firstCandidate = candidates[0];

                    if (firstCandidate.TryGetProperty("content", out JsonElement content) &&
                        content.TryGetProperty("parts", out JsonElement parts) &&
                        parts.GetArrayLength() > 0)
                    {
                        var firstPart = parts[0];

                        if (firstPart.TryGetProperty("text", out JsonElement textElement))
                        {
                            return textElement.GetString();
                        }
                    }
                }
                return null;
            }
        }
        catch (JsonException)
        {
            return null; 
        }
    }
}
