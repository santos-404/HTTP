using System.Net;
using System.Net.Sockets;

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

    public void HandleClient(TcpClient client)
    {
        using var networkStream = client.GetStream();

        var lines = StreamUtils.GetLinesStream(networkStream).ToList();
        var parts = lines[0].Split(' ');
        var method = parts[0];
        var path = parts[1];

        if (method == "GET" && path == "/hello")
        {
            var response = "HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\nHello, World!";
            Console.WriteLine(response);
        }
        else
        {
            var response = "HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\nNot Found";
            Console.WriteLine(response);
        }
        // Se que no comprueba si lo que no es correcto es el metodo o la ruta
    }

}