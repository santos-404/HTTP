using System.Text;

namespace Http {

    internal class Program {

        private static void Main() {
            try {
                string filename = "message.txt";
                using FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

                byte[] buffer = new byte[8];
                int bytesRead;
                string line = ""; 

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {

                    int i = Array.IndexOf(buffer, (byte)'\n', 0, bytesRead);
                    if (i != -1) {
                        string start = Encoding.UTF8.GetString(buffer, 0, i);
                        line += start;

                        Console.Write(line);

                        line = Encoding.UTF8.GetString(buffer, i, bytesRead-i);

                    } else {
                        string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        line += chunk;
                    }
                }

            } catch (Exception e) {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");    
            } 
        }

    }
}
