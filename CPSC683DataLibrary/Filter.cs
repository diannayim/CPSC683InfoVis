using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace DataLibrary
{
    public enum FilterTerm
    {
        GreaterThan,
        LessThan,
        EqualTo
    }

    public class FilterObject
    {
        FilterTerm filterTerm;
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

        public static string ConvertFilterDictionaryToString()
        {
            string firstKey = dictionary.Keys.ToArray()[0];
            StringBuilder sb = new StringBuilder(HelperFunctions.FilterByString(firstKey, dictionary[firstKey][0].stringFilterTerm, dictionary[firstKey][0].valueToFilterOn));

            foreach (string s in dictionary.Keys)
            {
                foreach (FilterObject j in dictionary[s].Skip(1))
                    sb.Append(" or " + HelperFunctions.FilterByString(s, j.stringFilterTerm, j.valueToFilterOn));

            }

            return sb.ToString();
        }

        public static void SetFilterObjectsByColumn(string columnName, List<FilterObject> fol)
        {
            dictionary[columnName.Replace(' ', '_')] = fol;
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
