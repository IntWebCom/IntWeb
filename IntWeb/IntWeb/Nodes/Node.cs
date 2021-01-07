using IntWeb.Framework.Collections;
using IntWeb.Framework.Core.Translator;
using IntWeb.Framework.Defaults;

namespace IntWeb.Framework.Nodes
{
    public class Node
    {
        public NodesCollection Nodes { get; private set; } = new NodesCollection();

        public long Identifier { get; private set; } = GenerateNewIdentifier();

        public string GetIdentifierLabel()
        {
            return NodeDefaults.IdentifierLabelPrefix + Identifier;
        }

        private static long GenerateNewIdentifier()
        {
            return ApplicationNodesCounter.NextValue();
        }
    }
}
