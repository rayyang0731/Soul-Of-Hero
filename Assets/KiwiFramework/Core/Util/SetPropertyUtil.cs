using System.Collections.Generic;
using UnityEngine;

namespace KiwiFramework.Core
{
    public static class SetPropertyUtil
    {
        public static bool SetColor(ref Color currentValue, Color newValue)
        {
            if ((double) currentValue.r == (double) newValue.r && (double) currentValue.g == (double) newValue.g &&
                ((double) currentValue.b == (double) newValue.b && (double) currentValue.a == (double) newValue.a))
                return false;
            currentValue = newValue;
            return true;
        }

        public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
                return false;
            currentValue = newValue;
            return true;
        }

        public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
        {
            if ((object) currentValue == null && (object) newValue == null ||
                (object) currentValue != null && currentValue.Equals((object) newValue))
                return false;
            currentValue = newValue;
            return true;
        }
    }
}