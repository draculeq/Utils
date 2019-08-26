using UnityEngine;

namespace Assets.Deadbit.Utils.Extensions
{
    public static class FloatExt
    {
        public static float Map(this float s, float InMin, float InMax, float OutMin, float OutMax)
        {
            return OutMin + (s - InMin) * (OutMax - OutMin) / (InMax - InMin);
        }

        public static float MapClamped(this float s, float InMin, float InMax, float OutMin, float OutMax)
        {
            return Mathf.Clamp(OutMin + (s - InMin) * (OutMax - OutMin) / (InMax - InMin), Mathf.Min(OutMin, OutMax), Mathf.Max(OutMin, OutMax));
        }
    }
}
