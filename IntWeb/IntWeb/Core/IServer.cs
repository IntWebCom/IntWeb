namespace IntWeb.Framework.Core
{
    public interface IServer
    {
        void StartListen();

        void StopListen();
    }
}
