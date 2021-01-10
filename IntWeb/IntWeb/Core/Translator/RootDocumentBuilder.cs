using IntWeb.Framework.Defaults;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntWeb.Framework.Core.Translator
{
    public static class RootDocumentBuilder
    {
        public static string CreateHTML(
            List<string> stylesheetsSources,
            List<string> javascriptSources,
            Encoding encoding, 
            string rootTitle,
            string errorMessage = null)
        {
            string stylesheetsHTML = GetStylesheetTableHTML(stylesheetsSources);
            string javaScriptsHTML = GetJavaScriptTableHTML(javascriptSources);

            return @$"
                <!doctype html>
                <html>
                    <head>
                       <meta charset=""{encoding.WebName}"" />
                       <title>{rootTitle}</title>
                       {stylesheetsHTML}
                       {javaScriptsHTML}
                    </head>
                    <body>
                        <noscript>{GetErrorWithFormatHTML(CustomMessages.NoScript)}</noscript>
                        {(errorMessage == null ? GetMessageWithFormatHTML(CustomMessages.Preloader) : GetErrorWithFormatHTML(errorMessage))}
                    </body>
                 </html>
            ";
        }

        private static string GetStylesheetTableHTML(List<string> stylesheetsSources)
        {
            string html = string.Empty;

            foreach(string source in stylesheetsSources)
            {
                html += $@"<link rel = ""stylesheet"" href=""{source}"" />" + Environment.NewLine;
            }

            return html;
        }

        private static string GetJavaScriptTableHTML(List<string> javascriptSources)
        {
            string html = string.Empty;

            foreach (string source in javascriptSources)
            {
                html += $@"<script type=""text/javascript"" src=""{source}"" ></script>" + Environment.NewLine;
            }

            return html;
        }

        private static string GetMessageWithFormatHTML(string message)
        {
            return $"<b>{message}</b>";
        }

        private static string GetErrorWithFormatHTML(string errorMessage)
        {
            return $"<p><h1>{CustomMessages.Error + errorMessage}</h1></p>";
        }
    }
}
