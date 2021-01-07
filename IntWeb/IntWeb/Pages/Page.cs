using IntWeb.Framework.Collections;

namespace IntWeb.Framework.Pages
{
    public abstract class Page
    {
        public NodesCollection Nodes { get; private set; } = new NodesCollection();
    }
}
