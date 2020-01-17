using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonSite.Models
{
    public class LinkCollection
    {
        private static List<Link> links = new List<Link>();
        private static Link l1 = new Link();
        private static Link l2 = new Link();

        public static IEnumerable<Link> Bank
        {
            get
            {
                if (IsEmpty())
                    Initialize();
                return links;
            }
        }

        public static void Initialize()
        {
            l1.Url = "https://en.wikipedia.org/wiki/Stephen_Hawking";
            l2.Url = "https://en.wikipedia.org/wiki/A_Brief_History_of_Time";
            links.Add(l1);
            links.Add(l2);
        }

        public static bool IsEmpty()
        {
            bool empty;
            if (links.Count == 0)
            {
                empty = true;
                return empty;
            }
            else
            {
                empty = false;
                return empty;
            }
        }
    }
}
