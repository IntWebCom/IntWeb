using IntWeb.Framework.Collections;
using IntWeb.Framework.Managers;

namespace IntWeb.Framework
{
    public class Application
    {
        public string Name { get; private set; }

        public string DomainPrefix { get; private set; }

        public PagesCollection Pages { get; private set; } = new PagesCollection();

        public RoutesCollection Routes { get; private set; } = new RoutesCollection();

        public DirectoryManager DirectoryManager { get; private set; }

        public Application(string name, string domainPrefix)
        {
            Name = name;
            DomainPrefix = domainPrefix;

            DirectoryManager = new DirectoryManager(this);
            DirectoryManager.InitializeApplicationDirectory();
        }
    }
}