using System;
using UnityEngine;

namespace Deadbit.Utils.Extensions
{
    public static class ColorExt
    {
        public static String ToHex(this Color c)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", (int)(c.r * 255), (int)(c.g * 255), (int)(c.b * 255));
        }

        public static String ToRGB(this Color c)
        {
            return string.Format("RGB({0}{1}{2})", (int)(c.r * 255), (int)(c.g * 255), (int)(c.b * 255));
        }
    }
}
