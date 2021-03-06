﻿using DataLibrary;
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
        public int numOfEntries
        {
            get
            {
                return originalTable.Rows.Count;
            }
        }

        public List<string> dimensionNames
        {
            get
            {
                List<string> t = new List<string>();

                foreach(DataColumn c in originalTable.Columns)
                {
                    if (c.DataType == typeof(string))
                        t.Add(c.ColumnName);
                }

                return t;
            }
        }

        public List<string> measureNames
        {
            get
            {
                List<string> t = new List<string>();

                foreach (DataColumn c in originalTable.Columns)
                {
                    if (c.DataType == typeof(float))
                        t.Add(c.ColumnName);
                }

                t.Add("Score");
                t.Add("Hotel_stars");
                return t;
            }
        }

        public List<string> booleanNames
        {
            get
            {
                List<string> t = new List<string>();

                foreach (DataColumn c in originalTable.Columns)
                {
                    if (c.DataType == typeof(bool))
                        t.Add(c.ColumnName);
                }

                return t;
            }
        }


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
                        dc.ColumnName = s;
                        columnNames.Add(s);

                        switch (s)
                        {
                            case "User_country":
                            case "Period_of_stay":
                            case "Hotel_name":
                            case "User_continent":
                            case "Review_month":
                            case "Review_weekday":
                            case "Traveler_type":
                            case "Score":
                            case "Hotel_stars":
                                dc.DataType = typeof(string);
                                break;
                            case "Nr._reviews":
                            case "Nr._hotel_reviews":
                            case "Helpful_votes":
                            case "Nr._rooms":
                            case "Member_years":
                                dc.DataType = typeof(float);
                                break;
                            case "Pool":
                            case "Gym":
                            case "Tennis_court":
                            case "Spa":
                            case "Casino":
                            case "Free_internet":
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
            if (filter == null)
                return "";

            var filteredRows = originalTable.Select(filter);
            return ReturnJsonTable(filteredRows.CopyToDataTable());
        }
        
        public string GetIDWithFilter(string filter)
        {
            if (filter == null)
                return "";

            DataTable filteredRows = originalTable.Select(filter).CopyToDataTable();
            DataTable dt = new DataView(filteredRows).ToTable(false, new string[] { "id" });
            return ReturnJsonTable(dt);
        }

        public float GetAverageValue(string columnName, string filter)
        {
            return (float)originalTable.Compute("AVG([" + columnName + "])", filter);
        }

        public List<string> GetUniqueValuesForColumn(string columnName)
        {
            DataView view = new DataView(originalTable);
            DataTable distinctValues = view.ToTable(true, columnName);

            return distinctValues.AsEnumerable().Select(r => r[columnName].ToString()).ToList();
        }

        public List<string> GetUniqueValuesForColumn(string columnName, string filter)
        {
            var filteredRows = originalTable.Select(filter);
            DataView view = new DataView(filteredRows.CopyToDataTable());
            DataTable distinctValues = view.ToTable(true, columnName);

            return distinctValues.AsEnumerable().Select(r => r[columnName].ToString()).ToList();
        }
    }
}
