using IntWeb.Framework.Defaults;
using System.IO;
using System.Net;
using System.Text;

namespace IntWeb.Framework.Core.WebServer
{
    public class HttpWebServer : IServer
    {
        public bool IsListen { get; set; } = false;

        public Application Application { get; private set; }

        public WebHeaderCollection Headers { get; set; }

        private readonly HttpListener httpListener = new HttpListener();

        private string[] addresses;

        private int port;

        public HttpWebServer(Application application)
        {
            Application = application;
        }

        public void UseConnectionOn(string[] addresses, int port)
        {
            this.addresses = addresses;
            this.port = port;
        }

        public void StartListen()
        {
            IsListen = true;

            RestoreListener();

            while (IsListen)
            {
                HttpListenerContext context = httpListener.GetContext();

                AddHeaders(context.Response);

                HandleRequest(context.Request, context.Response);

                context.Response.Close();
            }

            httpListener.Stop();
        }

        public void StopListen()
        {
            httpListener.Stop();
        }

        private void RestoreListener()
        {
            foreach (string address in addresses)
            {
                httpListener.Prefixes.Add($"http://{address}:{port}/");
            }

            httpListener.Start();
        }

        private void HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string data = new StreamReader(request.InputStream, request.ContentEncoding).ReadToEnd(); //TODO using

            ExecutionResult executionResult = ResponseBuilder.CreateResponse(Application, request);
            SendResponse(response, executionResult, request.ContentEncoding);
        }

        private void AddHeaders(HttpListenerResponse response)
        {
            response.Headers = Headers ?? GetDefaultHeaders();
        }

        private void SendResponse(HttpListenerResponse response, ExecutionResult executionResult, Encoding encoding)
        {
            response.StatusCode = executionResult.StatusCode;

            if (executionResult.ResponseBody == null)
            {
                return;
            }

            byte[] responseBytes = encoding.GetBytes(executionResult.ResponseBody);
            response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
        }

        private WebHeaderCollection GetDefaultHeaders()
        {
            WebHeaderCollection headers = new WebHeaderCollection
            {
                { "Server", NetworkDefaults.ServerName },
                { "Content-Type", GetContentTypeHeader() }
            };

            return headers;
        }

        private string GetContentTypeHeader()
        {
            return $"text/html; charset={Application.Encoding.WebName}";
        }
    }
}
