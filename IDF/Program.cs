using IDF.Giminy_feutre;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


class Program
{
    static async Task Main(string[] args)
    {
        string apiKeyPath = @"C:\Users\itai\source\repos\IDF\IDF\Giminy feutre\api_key.env"; 

        if (!File.Exists(apiKeyPath))
        {
            Console.WriteLine("'apy_key.env'don't found.");
            return;
        }

        string apiKey = File.ReadAllText(apiKeyPath).Trim();

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("NOT VALID API_KEY.");
            return;
        }

        var client = new GeminiClient(apiKey);
        var ui = new ConsoleInterface(client);
        await ui.RunAsync();
    }
}
