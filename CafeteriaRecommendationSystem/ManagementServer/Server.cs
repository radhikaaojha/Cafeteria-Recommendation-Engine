﻿using CMS.Common.Models;
using Common;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ManagementServer
{
    public class Server
    {
        private ClientRequestProcessor _clientRequestProcessor;

        public Server(ClientRequestProcessor clientRequestProcessor)
        {
            this._clientRequestProcessor = clientRequestProcessor;
        }

        public async Task Start()
        {
            TcpListener server = null;
            try
            {
                IPAddress ipAddress = IPAddress.Parse(AppConstants.SERVER_IP);
                server = new TcpListener(ipAddress, AppConstants.PORT);
                server.Start();
                Console.WriteLine($"Server started on {ipAddress}:{AppConstants.PORT}");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Client {client.Client.RemoteEndPoint} connected");
                    Task.Run(() => _clientRequestProcessor.HandleClientRequest(client));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }

       
    }
}