using IntWeb.Framework.Routing;
using System.Collections;
using System.Collections.Generic;

namespace IntWeb.Framework.Collections
{
    public class RoutesCollection : IEnumerable
    {
        readonly List<Route> routes = new List<Route>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return routes.GetEnumerator();
        }
    }
}