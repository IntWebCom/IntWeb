using IntWeb.Framework.Pages;
using System.Collections;
using System.Collections.Generic;

namespace IntWeb.Framework.Collections
{
    public class PagesCollection : IEnumerable
    {
        List<Page> pages = new List<Page>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var index = 0; index < pages.Count; index++)
            {
                yield return pages[index];
            }
        }
    }
}
