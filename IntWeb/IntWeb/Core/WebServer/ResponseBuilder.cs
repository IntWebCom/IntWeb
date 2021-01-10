using IntWeb.Framework.Core.Translator;
using IntWeb.Framework.Enums;
using System.Collections.Generic;
using System.Net;

namespace IntWeb.Framework.Core.WebServer
{
    public static class ResponseBuilder
    {
        public static ExecutionResult CreateResponse(Application application, HttpListenerRequest request)
        {
            ExecutionResult executionResult = new ExecutionResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                ResponseBody = CreateResponseBody(application, request)
            };

            return executionResult;
        }

        private static string CreateResponseBody(Application application, HttpListenerRequest request)
        {
            List<string> stylesheetsSources = application.Sources.GetSourcesByType(SourceType.Stylesheet);
            List<string> javascriptSources  = application.Sources.GetSourcesByType(SourceType.JavaScript);

            return RootDocumentBuilder.CreateHTML(stylesheetsSources, javascriptSources, application.Encoding, application.Name);
        }
    }
}
