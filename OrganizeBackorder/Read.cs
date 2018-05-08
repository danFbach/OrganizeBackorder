using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OrganizeBackorder
{
    class Read
    {
        public List<string> Reader()
        {
            List<string> lines = new List<string>();
            string location = "C:\\INVEN\\EXPORT.txt";
            if (File.Exists(location))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(location))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File is unreadable");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist;");
                return null;
            }
            return lines;
        }
    }
}
