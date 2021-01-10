using IntWeb.Framework.Collections;
using IntWeb.Framework.Core.WebServer;
using IntWeb.Framework.Core.WebSocketServer;
using IntWeb.Framework.Defaults;
using IntWeb.Framework.Enums;
using IntWeb.Framework.Managers;
using IntWeb.Framework.Threading;
using System.Text;

namespace IntWeb.Framework
{
    public class Application
    {
        public string Name { get; private set; }

        public HttpWebServer HttpWebServer { get; private set; }

        public WebSocketServer WebSocketServer { get; private set; }

        public PagesCollection Pages { get; private set; } = new PagesCollection();

        public RoutesCollection Routes { get; private set; } = new RoutesCollection();

        public SourcesCollection Sources { get; private set; } = new SourcesCollection();

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public DirectoryManager DirectoryManager { get; private set; }

        public ThreadsWorker ThreadsWorker { get; private set; } = new ThreadsWorker();

        public Application(string name)
        {
            Name = name;

            DirectoryManager = new DirectoryManager(this);
            DirectoryManager.InitializeApplicationDirectory();

            HttpWebServer = new HttpWebServer(this);
        }

        public void Bind(
            string domainPrefix, 
            string webSocketServerAddress, 
            int webServerPort = NetworkDefaults.DefaultWebServerPort, 
            int webSocketServerPort = NetworkDefaults.DefaultWebSocketServerPort)
        {
            Bind(new string[] { domainPrefix }, webSocketServerAddress, webServerPort, webSocketServerPort);
        }

        public void Bind(
            string[] domainPrefixes, 
            string webSocketServerAddress, 
            int webServerPort = NetworkDefaults.DefaultWebServerPort, 
            int webSocketServerPort = NetworkDefaults.DefaultWebSocketServerPort)
        {
            HttpWebServer.UseConnectionOn(domainPrefixes, webServerPort);
            ThreadsWorker.StartInThread(HttpWebServer.StartListen);

            //TODO WebSocketServer implementation
        }

        public void IncludeStylesheetFile(string fileUrl)
        {
            Sources.SetSource(SourceType.Stylesheet, fileUrl);
        }

        public void IncludeJavaScriptFile(string fileUrl)
        {
            Sources.SetSource(SourceType.JavaScript, fileUrl);
        }
    }
}