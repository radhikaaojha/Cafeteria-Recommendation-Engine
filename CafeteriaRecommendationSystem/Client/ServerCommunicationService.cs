using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class ServerCommunicationService
    {
        private readonly StreamWriter _writer;
        private readonly StreamReader _reader;
        public ServerCommunicationService(StreamWriter writer, StreamReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public async Task<CustomProtocol> SendRequestAsync(StreamWriter writer, StreamReader reader, CustomProtocol request)
        {
            string requestString = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                MaxDepth = 128
            });
            await writer.WriteLineAsync(requestString.Length.ToString());
            await writer.WriteLineAsync(requestString);
            var response = await HandleServerResponse(reader);
            return response;
        }

        private async Task<CustomProtocol> HandleServerResponse(StreamReader reader)
        {
            CustomProtocol response = new();
            while (true)
            {
                string lengthString = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(lengthString))
                {
                    continue;
                }

                if (!int.TryParse(lengthString, out int dataLength))
                {
                    Console.WriteLine("Invalid data length received from server.");
                    continue;
                }

                char[] buffer = new char[dataLength];
                int bytesRead = await reader.ReadAsync(buffer, 0, dataLength);
                if (bytesRead != dataLength)
                {
                    Console.WriteLine("Unexpected data length received from server.");
                    continue;
                }

                string responseData = new string(buffer);
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                        MaxDepth = 128
                    };
                    response = JsonSerializer.Deserialize<CustomProtocol>(responseData);
                    return response;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                }

            }
        }
    }
}
