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

        public static Color HexRGBToColor(this string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            return new Color(r / 255f, g / 255f, b / 255f);
        }

        public static Color HexRGBAToColor(this string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte a = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}
