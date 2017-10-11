using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataTableClass
    {
        public DataTable table;

        public void WriteToTable(string pathName)
        {
            table = new DataTable("DataTable");

            foreach (string line in File.ReadLines(pathName))
            {
                if (table.Columns.Count == 0)
                {
                    string[] split = line.Split(',');

                    foreach (string s in split)
                    {
                        DataColumn dc = new DataColumn();
                        dc.DataType = typeof(string);
                        dc.ColumnName = s;
                        table.Columns.Add(dc);
                    }
                }

                else
                {
                    DataRow row = table.NewRow();

                    string[] split = line.Split(',');

                    for (int i = 0; i < split.Length; i++)
                    {
                        row[table.Columns[i].ColumnName] = split[i];
                    }
                    table.Rows.Add(row);
                }
            }
        }
        
        public string ReturnRow()
        {
            return JsonConvert.SerializeObject(table);
        }
    }
}
