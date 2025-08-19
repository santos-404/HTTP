using System.Text;

namespace Http {

    internal class Program {

        private static void Main() {
            try {
                string filename = "message.txt";
                using FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

                byte[] buffer = new byte[8];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                    string decodedChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Read {bytesRead} bytes. {decodedChunk}");
                }

            } catch (Exception e) {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");    
            } 
        }

    }
}
