using System.Text;

namespace Http {

    internal class Program {

        private static void Main() {
            try {
                using var fs = new FileStream("message.txt", FileMode.Open, FileAccess.Read); 
                foreach (var line in GetLinesStream(fs)) {
                    Console.Write(line);
                }

            } catch (Exception e) {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");    
            } 
        }

        private static IEnumerable<string> GetLinesStream(FileStream stream) {
            byte[] buffer = new byte[8];
            int bytesRead;
            string line = "";

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {

                int i = Array.IndexOf(buffer, (byte)'\n', 0, bytesRead);
                if (i != -1) {
                    string start = Encoding.UTF8.GetString(buffer, 0, i);
                    line += start;

                    yield return line;

                    // Here I'm saving the '\n'. I'm not sure if this is a good idea yet.
                    line = Encoding.UTF8.GetString(buffer, i, bytesRead-i);

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
