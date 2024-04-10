using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace DataTower.Core
{
    public class DT_CommonProps
    {
        [CanBeNull] private static Func<Dictionary<string, object>> _dynamicCommonPropsGetter;

        public static void SetDynamicCommonPropertiesGetter(Func<Dictionary<string, object>> getter)
        {
            _dynamicCommonPropsGetter = getter;
        }

        public static void ClearDynamicCommonPropertiesGetter()
        {
            _dynamicCommonPropsGetter = null;
        }

        public static void InsertDynamicProperties(Dictionary<string, object> target)
        {
            if (_dynamicCommonPropsGetter is null || target is null) return;

            Dictionary<string, object> dcp = _dynamicCommonPropsGetter.Invoke();
            if (dcp is null || dcp.Count == 0) return;
            
            foreach (KeyValuePair<string, object> pair in dcp)
            {
                if (target.ContainsKey(pair.Key)) continue;
                target[pair.Key] = pair.Value;
            }
        }
    }
}