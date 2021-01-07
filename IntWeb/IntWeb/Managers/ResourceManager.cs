namespace IntWeb.Framework.Managers
{
    public class ResourceManager
    {
        public string ResourceName { get; private set; }

        public ResourceManager(string resourceName)
        {
            ResourceName = resourceName;
        }
    }
}
