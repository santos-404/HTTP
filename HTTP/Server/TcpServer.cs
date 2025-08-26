using System.Net;
using System.Net.Sockets;
using Http.Requests;

namespace Http.Server;

public class TcpServer {

    private readonly int _port;
    private TcpListener? _listener;

    public TcpServer(int port){
        _port = port;
    }

    public void Start() {
        try {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            Console.WriteLine($"Server started on port {_port}...");

            while (true) {
                var client = _listener.AcceptTcpClient();
                HandleClient(client);
            }
        } catch (Exception e) {
            Console.Error.WriteLine($"An error ocurred: {e.Message}");    
        } 
    }

    public void HandleClient(TcpClient client) {
        using var networkStream = client.GetStream();

        Request request = new Request(networkStream);

    }
}
