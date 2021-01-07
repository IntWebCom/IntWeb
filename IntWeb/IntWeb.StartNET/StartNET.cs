using IntWeb.Framework;

namespace IntWeb.StartNET
{
    public static class StartNET
    {
        public static Application Application { get; private set; }

        public static void LoadDefaultContext()
        {
            Application = new Application("main", "localhost");
        }
    }
}
