using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganizeBackorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Read r = new Read();
            Organize o = new Organize();
            Write w = new Write();
            utilities u = new utilities();
            List<string> data = r.Reader();
            List<productData> _data = o.parseIn(data);
            List<entry> entries = o.pack(_data);
            List<IGrouping<string, entry>> sEntries = o.sort(entries);
            w.Writer(sEntries);
            u.display();
        }
    }
}
