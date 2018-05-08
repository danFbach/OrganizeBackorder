using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OrganizeBackorder
{
    class Write
    {
        public void Writer(List<IGrouping<string, entry>> data)
        {
            string location = "C:\\INVEN\\_EXPORT.txt";
            using (StreamWriter sw = new StreamWriter(location, false))
            {
                foreach(IGrouping<string, entry> d in data)
                {
                    string _blank = " PR ID |       DESCRIPTION       | CODE | ASS.TM | QTY ";
                    sw.WriteLine(_blank);
                    foreach (entry e in d)
                    {
                        if (e != null)
                        {
                            string temp = " " + (e.ProductNum + "         ").Remove(5) + " | " + (e.Description + "                         ").Remove(23) + " | " + (e.ProductCode + "     ").Remove(4) + " | " + (e.AssemblyTime + "      ").Remove(5) + "  | " + (e.Qty + "      ").Remove(5);
                            sw.WriteLine(temp);
                            if(e.parts != null && e.parts.Count > 0)
                            {
                                string blank = "    |*Part(s) on Backorder for " + (e.ProductNum + ":              ").Remove(16) + "  |";
                                sw.WriteLine(blank);
                                foreach (part p in e.parts)
                                {
                                    string partemp = "    | " + (p.partID + "      ").Remove(6) + " | " + (p.desc + "                          ").Remove(23) + "  | " + (p.vendor + "        ").Remove(6) + " |";
                                    sw.WriteLine(partemp);
                                }
                                sw.WriteLine("     --------------------------------------------");
                            }
                        }
                    }
                    sw.WriteLine("-------|-------------------------|------|--------|-----");
                }
                sw.Close();
            }
        }
    }
}
