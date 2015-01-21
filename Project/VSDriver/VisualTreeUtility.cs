using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using System;
using System.Collections.Generic;

namespace VSDriver
{
    public static class VisualTreeUtility
    {
        public static dynamic IdentifyDescendantByTypeFullName(AppVar v, string typeFullName)
        {
            var items = GetDescendantByTypeFullName(v, typeFullName);
            if (items.Length != 1)
            {
                throw new NotSupportedException("Error Identify " + typeFullName);
            }
            return items[0];
        }

        public static dynamic[] GetDescendantByTypeFullName(AppVar v, string typeFullName)
        {
            List<dynamic> l = new List<dynamic>();
            foreach (dynamic e in v.App.Type(typeof(VisualTreeUtilityCore)).GetDescendantByTypeFullName(v, typeFullName))
            {
                l.Add(e);
            }
            return l.ToArray();
        }

        public static dynamic IdentifyAncestorByTypeFullName(AppVar v, string typeFullName)
        {
            var item = GetAncestorByTypeFullName(v, typeFullName);
            if (((AppVar)item).IsNull)
            {
                throw new NotSupportedException("Error Identify " + typeFullName);
            }
            return item;
        }

        public static dynamic GetAncestorByTypeFullName(AppVar v, string typeFullName)
        {
            return v.App.Type(typeof(VisualTreeUtilityCore)).GetAncestorByTypeFullName(v, typeFullName);
        }
    }
}
