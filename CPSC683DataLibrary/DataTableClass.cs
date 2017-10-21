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
        private DataTable originalTable;
        private DataTable filteredTable;
        public List<string> columnNames = new List<string>();

        #region Creation
        public void WriteToTable(string pathName)
        {
            originalTable = new DataTable("DataTable");
            
            foreach (string line in File.ReadLines(pathName))
            {
                if (originalTable.Columns.Count == 0)
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

                        originalTable.Columns.Add(dc);
                    }
                }

                else
                {
                    DataRow row = originalTable.NewRow();
                    string[] split = line.Split(',');

                    for (int i = 0; i < split.Length; i++)
                    {
                        if (originalTable.Columns[i].DataType == typeof(bool))
                        {
                            if (split[i] == "YES")
                                row[originalTable.Columns[i].ColumnName] = true;
                            else
                                row[originalTable.Columns[i].ColumnName] = false;
                        }

                        else if (originalTable.Columns[i].DataType == typeof(TravelerType))
                        {
                            row[originalTable.Columns[i].ColumnName] = Enum.Parse(typeof(TravelerType), split[i]);
                        }

                        else
                        {
                            row[originalTable.Columns[i].ColumnName] = split[i];
                        }
                    }
                    originalTable.Rows.Add(row);
                }
            }

            filteredTable = originalTable;
        }
        #endregion

        #region Return To Unity
        public string ReturnJsonTable()
        {
            return JsonConvert.SerializeObject(originalTable);
        }

        public string ReturnJsonTable(DataTable t)
        {
            return JsonConvert.SerializeObject(t);
        }

        #endregion

        public int GetNumberOfEntriesWithColumnValue(string filter)
        {
            return filteredTable.Select(filter).Length;
        }

        public string GetRowsWithFilter(string filter)
        {
            var filteredRows = originalTable.Select(filter);
            return ReturnJsonTable(filteredRows.CopyToDataTable());
        }

        public float GetAverageValue(string columnName, string filter)
        {
            return (float)originalTable.Compute("AVG([" + columnName.Replace(' ', '_') + "])", filter);
        }

        public string FilterByString(string columnName, string operation, string columnValue)
        {
            return columnName.Replace(' ', '_') + " " + operation + " \'" + columnValue + "\'";
        }
        
        public List<string> GetUniqueValuesForColumn(string columnName)
        {
            DataView view = new DataView(originalTable);
            DataTable distinctValues = view.ToTable(true, columnName.Replace(' ', '_'));

            return distinctValues.AsEnumerable().Select(r => r[columnName.Replace(' ', '_')].ToString()).ToList();
        }

        public List<string> GetUniqueValuesForColumn(string columnName, string filter)
        {
            var filteredRows = originalTable.Select(filter);
            DataView view = new DataView(filteredRows.CopyToDataTable());
            DataTable distinctValues = view.ToTable(true, columnName.Replace(' ', '_'));

            return distinctValues.AsEnumerable().Select(r => r[columnName.Replace(' ', '_')].ToString()).ToList();
        }
    }
}
