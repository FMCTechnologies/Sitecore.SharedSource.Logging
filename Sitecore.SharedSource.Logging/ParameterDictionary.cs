using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sitecore.SharedSource.Logging
{
    public class ParameterDictionary : Dictionary<string, object>
    {
        /// <summary>
        /// var parameters = new ParameterDictionary(new { param1, param2, param3 });
        /// </summary>
        /// <param name="values"></param>
        public ParameterDictionary(object values)
        {
            if(values == null)
                return;

            foreach(PropertyDescriptor property in TypeDescriptor.GetProperties(values))
                Add(property.Name, property.GetValue(values));   
        }
    }
 
    public static class ParameterDictionaryExtensions
    {
        public static string GetString(this ParameterDictionary parameterDictionary)
        {
            var results = new StringBuilder();
            if (parameterDictionary == null) return string.Empty;

            foreach (var param in parameterDictionary)
            {
                if (results.Length > 0) results.Append(",");
                results.Append(String.Format("{0}={1}", param.Key, param.Value));
            }
            return results.Length == 0 ? string.Empty : String.Format("({0})", results);
        }
    }
}
