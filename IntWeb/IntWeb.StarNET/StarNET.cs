using IntWeb.Framework;

namespace IntWeb.StarNET
{
    public static class StarNET
    {
        public static Application Application { get; private set; }

        public static void LoadDefaultContext()
        {
            Application = new Application("main");
        }
    }
}
