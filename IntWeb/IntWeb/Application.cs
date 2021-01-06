namespace IntWeb.Framework
{
    public class Application
    {
        public string DomainPrefix { get; private set; }

        public Application(string domainPrefix)
        {
            DomainPrefix = domainPrefix;
        }
    }
}
