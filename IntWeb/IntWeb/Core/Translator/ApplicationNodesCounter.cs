namespace IntWeb.Framework.Core.Translator
{
    public static class ApplicationNodesCounter
    {
        private static long value = 0;

        public static long NextValue()
        {
            return value++;
        }
    }
}
