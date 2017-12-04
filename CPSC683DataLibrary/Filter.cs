using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using UnityEngine;

namespace DataLibrary
{
    public enum FilterTerm
    {
        GreaterThan,
        LessThan,
        EqualTo,
        NotEqualTo
    }

    public class FilterObject
    {
        public FilterTerm filterTerm;
        public string valueToFilterOn;

        public string stringFilterTerm
        {
            get
            {
                return ConvertFilterTermToString(filterTerm);
            }
        }

        public static string ConvertFilterTermToString(FilterTerm filter)
        {
            string f;

            switch (filter)
            {
                case FilterTerm.EqualTo:
                case FilterTerm.NotEqualTo:
                    f = "=";
                    break;
                case FilterTerm.GreaterThan:
                    f = "<";
                    break;
                case FilterTerm.LessThan:
                    f = ">";
                    break;
                default:
                    throw new NotImplementedException();
            }

            return f;
        }

        public static FilterTerm ConvertStringToFilterTerm(string filter)
        {
            FilterTerm f;

            switch (filter)
            {
                case "=":
                    f = FilterTerm.EqualTo;
                    break;
                case "<":
                    f = FilterTerm.GreaterThan;
                    break;
                case ">":
                    f = FilterTerm.LessThan;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return f;
        }

        public FilterObject(FilterTerm _filterTerm, string _value)
        {
            filterTerm = _filterTerm;
            valueToFilterOn = _value;
        }
    }

    public static class Filter
    {
        private static Dictionary<string, List<FilterObject>> dictionary = new Dictionary<string, List<FilterObject>>();

        public static void AddToDictionary(string filterString)
        {
            string[] split = filterString.Split(' ');
            FilterObject fo = new FilterObject(FilterObject.ConvertStringToFilterTerm(split[1]), split[2]);

            if (dictionary[split[0]] == null)
                dictionary[split[0]] = new List<FilterObject>();

            dictionary[split[0]].Add(fo);
        }

        public static string ConvertFilterDictionaryToString(FilterTerm filter)
        {
            string firstKey = dictionary.Keys.ToArray()[0];
            StringBuilder sb = new StringBuilder();

            foreach (string s in dictionary.Keys)
            {
                foreach (FilterObject j in dictionary[s])
                {
                    if (j.filterTerm == filter)
                    {
                        if (sb.Length > 0)
                            sb.Append(" or ");
                        
                        sb.Append(HelperFunctions.FilterByString(s, j.stringFilterTerm, j.valueToFilterOn));
                    }
                }
            }
            
            if (sb.Length == 0)
                return null;
            else
                return sb.ToString();
        }

        public static void SetFilterObjectsByColumn(string columnName, List<FilterObject> fol)
        {
            dictionary[columnName] = fol;
        }

        public static bool ReturnAllFilterValuesForColumn(string columnName, out List<string> list)
        {
            list = new List<string>();

            if (dictionary.ContainsKey(columnName))
            {
                foreach (FilterObject fo in dictionary[columnName])
                    list.Add(fo.valueToFilterOn);

                return true;
            }

            else
                return false;

        }
    }
}
