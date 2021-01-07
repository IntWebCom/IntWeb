using IntWeb.Framework.Collections;
using IntWeb.Framework.Core.WebServer;
using IntWeb.Framework.Core.WebSocketServer;
using IntWeb.Framework.Managers;
using System;

namespace IntWeb.Framework
{
    public class Application
    {
        public string Name { get; private set; }

        public HttpWebServer HttpWebServer { get; private set; }

        public WebSocketServer WebSocketServer { get; private set; }

        public PagesCollection Pages { get; private set; } = new PagesCollection();

        public RoutesCollection Routes { get; private set; } = new RoutesCollection();

        public DirectoryManager DirectoryManager { get; private set; }

        public Application(string name)
        {
            Name = name;

            DirectoryManager = new DirectoryManager(this);
            DirectoryManager.InitializeApplicationDirectory();
        }

        public void Bind(string domainPrefix, string webSocketServerAddress, int webServerPort, int webSocketServerPort)
        {
            Bind(new string[] { domainPrefix }, webSocketServerAddress, webServerPort, webSocketServerPort);
        }

        public void Bind(string[] domainPrefixes, string webSocketServerAddress, int webServerPort, int webSocketServerPort)
        {
            throw new NotImplementedException();
        }
    }
}