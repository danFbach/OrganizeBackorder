using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganizeBackorder
{
    class productData
    {
        public List<string> ProductData { get; set; }
        public List<partData> parts { get; set; }
    }
    class partData
    {
        public List<string> _partData { get; set; }
    }
    class entry
    {
        public string ProductNum { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string AssemblyTime { get; set; }
        public string Qty { get; set; }
        public List<part> parts { get; set; }
    }
    class part
    {
        public string partID { get; set; }
        public string desc { get; set; }
        public string vendor { get; set; }
    }
    class Organize
    {
        public List<productData> parseIn(List<string> data)
        {
            List<productData> pd = new List<productData>();
            List<List<string>> linePack = new List<List<string>>();
            productData _pd = new productData();
            partData partdata = new partData();
            List<string> a = new List<string>();
            foreach (string d in data)
            {
                a = new List<string>();
                a = d.Split('|').ToList();
                _pd = new productData();
                _pd.ProductData = a.Last().Split(',').ToList();
                if (a.Count() > 1)
                {
                    a.Remove(a.Last());
                    _pd.parts = new List<partData>();
                    foreach (string _a in a)
                    {
                        partdata = new partData();
                        partdata._partData = _a.Split(',').ToList();
                        _pd.parts.Add(partdata);
                    }
                }
                pd.Add(_pd);
            }
            return pd;
        }

        public List<entry> pack(List<productData> data)
        {
            List<entry> entries = new List<entry>();
            entry e = new entry();

            foreach (productData d in data)
            {
                e = new entry();
                if (!String.IsNullOrEmpty(d.ProductData[0].Trim())) { e.ProductNum = d.ProductData[0].Trim(); } else { e.ProductNum = ""; }
                if (!String.IsNullOrEmpty(d.ProductData[1])) { e.Description = d.ProductData[1]; } else { e.Description = ""; }
                if (!String.IsNullOrEmpty(d.ProductData[2].Trim())) { e.ProductCode = d.ProductData[2].Trim(); } else { e.ProductCode = ""; }
                if (!String.IsNullOrEmpty(d.ProductData[3].Trim())) { e.AssemblyTime = d.ProductData[3].Trim(); } else { e.AssemblyTime = ""; }
                if (!String.IsNullOrEmpty(d.ProductData[4].Trim())) { e.Qty = d.ProductData[4].Trim(); } else { e.Qty = ""; }
                if(d.parts != null && d.parts.Count > 0)
                {
                    e.parts = new List<part>();
                    part p = new part();
                    foreach (partData pd in d.parts)
                    {
                        p = new part();
                        if (!String.IsNullOrEmpty(pd._partData[0].Trim())) { p.partID = pd._partData[0].Trim(); } else { p.partID = ""; }
                        if (!String.IsNullOrEmpty(pd._partData[1].Trim())) { p.desc = pd._partData[1].Trim(); } else { p.desc = ""; }
                        if (!String.IsNullOrEmpty(pd._partData[2].Trim())) { p.vendor = pd._partData[2].Trim(); } else { p.vendor = ""; }
                        e.parts.Add(p);
                    }
                }
                entries.Add(e);
            }

            return entries;
        }
        public List<IGrouping<string, entry>> sort(List<entry> entries)
        {
            List<List<entry>> entryPacks = new List<List<entry>>();
            entries = entries.OrderBy(x => x.ProductCode).ToList();
            List<IGrouping<string, entry>> ee = entries.GroupBy(x => x.ProductCode).ToList();
            foreach (IGrouping<string, entry> e in ee)
            {
                e.OrderBy(x => x.ProductNum);
            }
            return ee;
        }
    }
}
