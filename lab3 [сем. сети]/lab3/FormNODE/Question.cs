using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormNODE
{
    public class Question
    {
        //Кораблев Алексей - AcoaAera
        private List<LinksTypes> links;

        public Question(string text)
        {
            Text = text;
            links = new List<LinksTypes>();
        }

        public void LinkAdd(LinksTypes link)
        {
            links.Add(link);
        }

        public List<LinksTypes> GetLinks()
        {
            return links;
        }

        public string Text
        {
            get;
            private set;
        }
    }
}
