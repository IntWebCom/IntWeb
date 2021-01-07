using IntWeb.Framework.Routing;
using System.Collections;
using System.Collections.Generic;

namespace IntWeb.Framework.Collections
{
    public class RoutesCollection : IEnumerable
    {
        List<Route> routes = new List<Route>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var index = 0; index < routes.Count; index++)
                yield return routes[index];
        }
    }
}