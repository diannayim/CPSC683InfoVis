using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTableClass dtc = new DataTableClass();

            string path = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString(), "LasVegasData.csv");

            dtc.WriteToTable(path);
        }
    }
}
