using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Http {

    internal class Program {

        private static void Main() {
            try {
                var listener = new TcpListener(IPAddress.Any, 42069);
                listener.Start();
                Console.WriteLine("Server started on port 42069...");

                while (true) {
                    var client = listener.AcceptTcpClient();
                    using var networkStream = client.GetStream();

                    foreach (var line in GetLinesStream(networkStream)) {
                        Console.WriteLine(line);
                    }
                }

            } catch (Exception e) {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");    
            } 
        }

        private static IEnumerable<string> GetLinesStream(NetworkStream stream) {
            byte[] buffer = new byte[8];
            int bytesRead;
            string line = "";

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {

                int i = Array.IndexOf(buffer, (byte)'\n', 0, bytesRead);
                if (i != -1) {
                    string startOfCurrentChunk = Encoding.UTF8.GetString(buffer, 0, i);
                    line += startOfCurrentChunk;

                    yield return line;

                    // Here we are skipping the '\n' byte
                    string endOfCurrentChunk = Encoding.UTF8.GetString(buffer, i+1, bytesRead-i-1);
                    line = endOfCurrentChunk;  // We reset the line to the reamining part of the chunk

                } else {
                    string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    line += chunk;
                }
            }

            if (!string.IsNullOrEmpty(line)) {
                yield return line;
            }

        }

    }
}
