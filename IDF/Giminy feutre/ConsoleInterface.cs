using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.Giminy_feutre
{
    internal class ConsoleInterface
    {

        private readonly GeminiClient _client;

        public ConsoleInterface(GeminiClient client)
        {
            _client = client;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.Write("Type your prompt (or 'exit' to quit): ");
                string prompt = Console.ReadLine();

                if (prompt?.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! hope to see you soon");
                    break;
                }

                string response = await _client.GenerateContentAsync(prompt);
                string text = ResponseParser.ExtractText(response);

                Console.WriteLine(!string.IsNullOrEmpty(text) ? text : response);
            }
        }
    }

}

