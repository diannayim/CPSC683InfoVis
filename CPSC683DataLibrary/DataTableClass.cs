using DataLibrary;
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
    /// <summary>
    /// DataTableClass for storing data information
    /// </summary>
    public class DataTableClass
    {
        private DataTable originalTable;
        private DataTable filteredTable;

        /// <summary>
        /// Column Names for dataset
        /// </summary>
        public List<string> columnNames = new List<string>();

        #region Creation

        /// <summary>
        /// Parses file at path into datatable object
        /// </summary>
        /// <param name="pathName">Path to file</param>
        public void WriteToTable(string pathName)
        {
            originalTable = new DataTable("DataTable");

            foreach (string line in File.ReadLines(pathName))
            {
                if (originalTable.Columns.Count == 0)
                {
                    string[] split = line.Split(',');
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "id";
                    dc.AutoIncrement = true;
                    columnNames.Add("id");
                    originalTable.Columns.Add(dc);

                    foreach (string s in split)
                    {
                        dc = new DataColumn();
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
                            case "Traveler type":
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
                        if (originalTable.Columns[i + 1].DataType == typeof(bool))
                        {
                            if (split[i] == "YES")
                                row[originalTable.Columns[i + 1].ColumnName] = true;
                            else
                                row[originalTable.Columns[i + 1].ColumnName] = false;
                        }

                        else
                        {
                            row[originalTable.Columns[i + 1].ColumnName] = split[i];
                        }
                    }
                    originalTable.Rows.Add(row);
                }
            }

            filteredTable = originalTable;
        }
        #endregion

        #region Return To Unity

        /// <summary>
        /// Returns original table in JSON format
        /// </summary>
        /// <returns>JSON Table</returns>
        public string ReturnJsonTable()
        {
            return JsonConvert.SerializeObject(originalTable);
        }

        /// <summary>
        /// Returns passed in table in JSON format
        /// </summary>
        /// <param name="t">DataTable to be converted into JSON</param>
        /// <returns>JSON of DataTable</returns>
        public string ReturnJsonTable(DataTable t)
        {
            return JsonConvert.SerializeObject(t);
        }

        #endregion

        /// <summary>
        /// Get number of entries for a filter
        /// </summary>
        /// <param name="filter">Filter (if required) for the number of elements to return</param>
        /// <returns>Number of entries within filtered datatable</returns>
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
