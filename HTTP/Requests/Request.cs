using System.Net.Sockets;

namespace Http.Requests;

public class Request {

    public RequestLine RequestLine { get; private set; } 

    public Request(NetworkStream stream) {
            using var reader = new StreamReader(stream, leaveOpen: true); 

            // Maybe is a good option to "override" this readline method
            string? firstLine = reader.ReadLine();
            if (string.IsNullOrEmpty(firstLine)) 
                throw new InvalidOperationException("Empty request line");

            RequestLine = new RequestLine(firstLine);
    }
}


public class RequestLine {
    public string Method { get; private set; } 
    public string RequestTarget { get; private set; } 
    public string HttpVersion { get; private set; } 

    public RequestLine(string line) {
        string[] splits = line.Split(' ');         
        if (splits.Length != 3) 
            throw new InvalidOperationException($"Invalid request line: {line}");

        Method = splits[0]; 
        RequestTarget = splits[1]; 
        HttpVersion = splits[2]; 

        if (!validateHttp()) 
            throw new InvalidOperationException("HTTP version not supported");
    }

    // Atm we only support 1.1
    private bool validateHttp () {
        return HttpVersion.Equals("HTTP/1.1");
    }


}

