using IntWeb.Framework.Enums;
using System.Collections;
using System.Collections.Generic;

namespace IntWeb.Framework.Collections
{
    public class SourcesCollection : IEnumerable
    {
        readonly Dictionary<string, SourceType> sources = new Dictionary<string, SourceType>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return sources.GetEnumerator();
        }

        public List<string> GetSourcesByType(SourceType sourceType)
        {
            List<string> keys = new List<string>();

            foreach(var sourceKey in sources.Keys)
            {
                if(sources[sourceKey] == sourceType)
                {
                    keys.Add(sourceKey);
                }
            }

            return keys;
        }

        public void SetSource(SourceType sourceType, string url)
        {
            sources[url] = sourceType;
        }

        public void UnsetSource(string url)
        {
            sources.Remove(url);
        }
    }
}