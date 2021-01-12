using IntWeb.Framework.Pages;
using System.Collections;
using System.Collections.Generic;

namespace IntWeb.Framework.Collections
{
    public class PagesCollection : IEnumerable
    {
        readonly List<Page> pages = new List<Page>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return pages.GetEnumerator();
        }
    }
}
