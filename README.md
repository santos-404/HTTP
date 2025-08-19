
# HTTP from scratch in C#

This project is a personal exercise to understand how the HTTP protocol works by building it on top of TCP sockets in C#. Instead of using ASP.NET or any of the built-in web frameworks, the goal is to go step by step from raw TCP communication up to a functioning HTTP server.

The implementation will start small: opening a TCP listener, reading raw bytes, and sending back minimal HTTP responses that can be tested with curl or a browser. From there, the plan is to expand the server to properly parse HTTP requests, handle headers, and return meaningful responses. Eventually, the idea is to serve files, manage multiple connections, and get a deeper understanding of the request/response lifecycle.

The project is not intended to replace existing HTTP servers or frameworks. It is purely for learning purposes, exploring how protocols work under the hood, and getting hands-on practice with low-level C# programming.

## Roadmap

1. create a console application with .NET
2. open a tcp listener and accept connections
3. send a hardcoded http response
4. parse basic http requests
5. serve static files in small chunks
6. expand request parsing and support multiple clients

## Requirements

- .NET 6 or later
- basic knowledge of C#, TCP, and HTTP

## License

This project is licensed under the MIT license.

Everyone is welcome to contribute; issues, suggestions, and pull requests are highly appreciated!

