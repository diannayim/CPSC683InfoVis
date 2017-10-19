using CPSC683DataLibrary;
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
        private DataTable table;
        public List<string> columnNames = new List<string>();

        #region Creation
        public void WriteToTable(string pathName)
        {
            table = new DataTable("DataTable");

            int id = 0;

            foreach (string line in File.ReadLines(pathName))
            {
                if (table.Columns.Count == 0)
                {
                    string[] split = line.Split(',');
                    
                    foreach (string s in split)
                    {
                        DataColumn dc = new DataColumn();
                        dc.ColumnName = s.Replace(' ', '_');
                        columnNames.Add(s);

                        switch (s)
                        {
                            case "User country":
                            case "Period of stay":
                            case "Hotel name":
                            case "User continent":
                            case "Review month":
                            case "Review weekday":
                                dc.DataType = typeof(string);
                                break;
                            case "Nr. reviews":
                            case "Nr. hotel reviews":
                            case "Helpful votes":
                            case "Score":
                            case "Hotel stars":
                            case "Nr. rooms":
                            case "Member years":
                                dc.DataType = typeof(float);
                                break;
                            case "Pool":
                            case "Gym":
                            case "Tennis court":
                            case "Spa":
                            case "Casino":
                            case "Free internet":
                                dc.DataType = typeof(bool);
                                break;
                            case "Traveler type":
                                dc.DataType = typeof(TravelerType);
                                break;
                            default:
                                dc.DataType = typeof(string);
                                break;
                        }

                        table.Columns.Add(dc);
                    }
                }

                else
                {
                    DataRow row = table.NewRow();
                    string[] split = line.Split(',');

                    for (int i = 0; i < split.Length; i++)
                    {
                        if (table.Columns[i].DataType == typeof(bool))
                        {
                            if (split[i] == "YES")
                                row[table.Columns[i].ColumnName] = true;
                            else
                                row[table.Columns[i].ColumnName] = false;
                        }

                        else if (table.Columns[i].DataType == typeof(TravelerType))
                        {
                            row[table.Columns[i].ColumnName] = Enum.Parse(typeof(TravelerType), split[i]);
                        }

                        else
                        {
                            row[table.Columns[i].ColumnName] = split[i];
                        }
                    }
                    table.Rows.Add(row);
                }
            }
        }
        #endregion

        #region Return To Unity
        public string ReturnJsonTable()
        {
            return JsonConvert.SerializeObject(table);
        }

        public string ReturnJsonTable(DataTable t)
        {
            return JsonConvert.SerializeObject(t);
        }

        #endregion

        public int GetNumberOfEntriesWithColumnValue(string filter)
        {
            return table.Select(filter).Length;
        }

        public string GetRowsWithFilter(string filter)
        {
            var filteredRows = table.Select(filter);
            return ReturnJsonTable(filteredRows.CopyToDataTable());
        }

        public float GetAverageValue(string columnName, string filter)
        {
            return (float)table.Compute("AVG([" + columnName.Replace(' ', '_') + "])", filter);
        }

        public string FilterByString(string columnName, string columnValue)
        {
            return columnName.Replace(' ', '_') + " = \'" + columnValue + "\'";
        }
        
        public List<string> GetUniqueValuesForColumn(string columnName)
        {
            DataView view = new DataView(table);
            DataTable distinctValues = view.ToTable(true, columnName.Replace(' ', '_'));

            return distinctValues.AsEnumerable().Select(r => r[columnName.Replace(' ', '_')].ToString()).ToList();
        }

        public List<string> GetUniqueValuesForColumn(string columnName, string filter)
        {
            var filteredRows = table.Select(filter);
            DataView view = new DataView(filteredRows.CopyToDataTable());
            DataTable distinctValues = view.ToTable(true, columnName.Replace(' ', '_'));

            return distinctValues.AsEnumerable().Select(r => r[columnName.Replace(' ', '_')].ToString()).ToList();
        }
    }
}
