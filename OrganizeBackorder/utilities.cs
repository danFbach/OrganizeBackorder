using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OrganizeBackorder
{
    class utilities
    {
        public void display()
        {
            string location = "C:\\INVEN\\_EXPORT.txt";
            string l2 = "Notepad.exe";
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = l2;
            psi.Arguments = location;
            psi.UseShellExecute = true;
            Process.Start(psi);
        }
    }
}
