using IntWeb.Framework;
using IntWeb.StarNET.Defaults;

namespace IntWeb.StarNET
{
    public static class StarNET
    {
        public static Application Application { get; private set; }

        public static void LoadDefaultContext()
        {
            Application = new Application("localhost");

            LoadDependencies();

            Application.Bind("localhost", "127.0.0.1", 8000);
        }

        private static void LoadDependencies()
        {
            Application.IncludeJavaScriptFile(Dependencies.JQueryJS);

            Application.IncludeStylesheetFile(Dependencies.BootstrapCSS);
            Application.IncludeJavaScriptFile(Dependencies.BootstrapJS);
        }
    }
}
