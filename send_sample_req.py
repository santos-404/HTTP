import socket

def main():
    host = "127.0.0.1"
    port = 42069

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((host, port))

        request = (
            "GET /hello HTTP/1.1\r\n"
            "Host: localhost\r\n"
            "User-Agent: PythonSocket\r\n"
            "\r\n"
        )

        s.sendall(request.encode("utf-8"))

        # With this we can handle responses from the server
        # try:
        #     response = s.recv(4096)
        #     if response:
        #         print("Response from server:")
        #         print(response.decode("utf-8", errors="ignore"))
        # except Exception:
        #     pass

if __name__ == "__main__":
    main()

