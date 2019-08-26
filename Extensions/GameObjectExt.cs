using System;
using UnityEngine;

namespace Assets.Deadbit.Utils.Extensions
{
    public static class GameObjectExt
    {
        public static bool IsNullOrDestroyed(GameObject obj)
        {
            return ReferenceEquals(obj, null) || obj.Equals(null);
        }

        public static void SetLayerRecursively(this GameObject obj, LayerMask layerFrom, LayerMask layerTo)
        {
            if (obj.layer == layerFrom)
                obj.layer = layerTo;

            foreach (Transform child in obj.transform)
            {
                child.gameObject.SetLayerRecursively(layerFrom, layerTo);
            }
        }

        public static T AddComponent<T>(this GameObject go, Action<T> injection) where T : MonoBehaviour
        {
            go.SetActive(false);
            var player = go.AddComponent<T>();
            injection(player);
            go.SetActive(true);
            return player;
        }
    }
}
