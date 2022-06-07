# congenial-octo-dollop
Chatty-Chat Web Chatting Application

The Chatty-Chat is an IRC style web chat application based on SignalR and ASP.NET Web Api. There is no need to register as user. Everybody can join the chat as long as the client can send HTTP upgrade request or can connect directly using Websocket protocol to establish persistent connection. 

SignalR and ASP.NET Web.Api will be used as a server. SignalR is used as it can automatically determine if Websocket is available and will fallback to Long Polling for persistent connection between Client and Server.

Any Web Clients as long as it support SignalR.js javascript library can be used. Also, can use ASP.NET MVC and Blazor as it natively support SignalR.


See DesignDiagram.pdf
