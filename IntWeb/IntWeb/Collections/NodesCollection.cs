using IntWeb.Framework.Nodes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IntWeb.Framework.Collections
{
    public class NodesCollection : IEnumerable
    {
        List<Node> nodes = new List<Node>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var index = 0; index < nodes.Count; index++)
                yield return nodes[index];
        }

        public T GetById<T>(long identifier) where T : Node
        {
            return (T)nodes.Where(node => node.Identifier == identifier).Single();
        }

        public T GetById<T>(string identifierLabel) where T : Node
        {
            return (T)nodes.Where(node => node.GetIdentifierLabel() == identifierLabel).Single();
        }
    }
}