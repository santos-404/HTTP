using Http.Server;

namespace Http;

internal class Program {

    private static void Main() {
        var server = new TcpServer(42069);
        server.Start();
    }
}
