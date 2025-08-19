namespace Http {

    internal class Program {

        private static void Main() {
            try {
                string filename = "message.txt";
                using FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

                byte[] buffer = new byte[8];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                    Console.WriteLine($"Read {bytesRead} bytes. {BitConverter.ToString(buffer, 0, bytesRead)}");
                }

            } catch (Exception e) {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");    
            } 
        }

    }
}
