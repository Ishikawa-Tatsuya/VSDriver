using System.Collections.Generic;
using System.Windows.Media;

namespace VSDriver
{
    static class VisualTreeUtilityCore
    {
        public static IEnumerable<Visual> GetDescendantByTypeFullName(Visual v, string typeFullName)
        {
            List<Visual> list = new List<Visual>();
            int count = VisualTreeHelper.GetChildrenCount(v);
            for (int i = 0; i < count; i++)
            {
                Visual next = VisualTreeHelper.GetChild(v, i) as Visual;
                if (next != null)
                {
                    if (next.GetType().FullName == typeFullName)
                    {
                        list.Add(next);
                    }
                    list.AddRange(GetDescendantByTypeFullName(next, typeFullName));
                }
            }
            return list;
        }

        public static Visual GetAncestorByTypeFullName(Visual v, string typeFullName)
        {
            if (v.GetType().FullName == typeFullName)
            {
                return v;
            }
            var parent = VisualTreeHelper.GetParent(v) as Visual;
            return parent == null ? null : GetAncestorByTypeFullName(parent, typeFullName);
        }
    }
}
