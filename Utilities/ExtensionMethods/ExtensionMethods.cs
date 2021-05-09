using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.ExtensionMethods
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class ValidatedNotNullAttribute : Attribute { }
    public static  class ExtensionMethods
    {
        public static bool IsNotNull<T>([ValidatedNotNullAttribute] this T valid) where T : class => valid != null;

        public static void TrimAll<T>(this T entity, params string[] ignoredFields)
        {
            Dictionary<Type, PropertyInfo[]> trimProperties = new Dictionary<Type, PropertyInfo[]>();
            if (!trimProperties.TryGetValue(typeof(T), out PropertyInfo[] props))
            {
                props = typeof(T)
                          .GetProperties()
                          .Where(c => !ignoredFields.Contains(c.Name) &&
                                      c.CanWrite &&
                                      c.PropertyType == typeof(string))
                          .ToArray();

                trimProperties.Add(typeof(T), props);
            }

            foreach (PropertyInfo property in props)
            {
                string value = Convert.ToString(property.GetValue(entity, null), CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(value))
                {
                    property.SetValue(entity, value.Trim(), null);
                }
            }
        }
    }
}
