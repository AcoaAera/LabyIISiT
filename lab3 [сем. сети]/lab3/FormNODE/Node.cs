using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormNODE
{
    public class Node
    {
        //Олег Москвичев - laceratione
        private List<Link> links;

        public Node(string nodeName)
        {
            Name = nodeName;
            links = new List<Link>();
        }

        public void LinkAdd(Link link)
        {
            links.Add(link);
        }

        public List<Link> GetLinks()
        {
            return links;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
