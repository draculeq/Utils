using UnityEngine;

namespace Deadbit.Utils.Extensions
{
    public static class CameraExt
    {
        public static Vector3 ViewportToWorld(this Camera camera, Vector3 point)
        {
            point.Scale(Vector3.one * 2);
            point -= Vector3.one;

            var cameraSpacePoint = camera.projectionMatrix.inverse.MultiplyPoint(point);
            cameraSpacePoint.Scale(new Vector3(1, 1, -1));
            return camera.transform.TransformPoint(cameraSpacePoint);
        }

        public static Vector3 ScreenToWorld(this Camera camera, Vector3 point)
        {
            var screenSize = GetScreenSize();
            return ViewportToWorld(camera, new Vector3(point.x / screenSize.x, point.y / screenSize.y, point.z));
        }

        public static Ray ScreenToRay(this Camera camera, Vector3 point)
        {
            var screenSize = GetScreenSize();
            var normalizedX = point.x / screenSize.x;
            var normalizedY = point.y / screenSize.y;
            var origin = ViewportToWorld(camera, new Vector3(normalizedX, normalizedY, 0));
            var target = ViewportToWorld(camera, new Vector3(normalizedX, normalizedY, 1));
            return new Ray(origin, target - origin);
        }

        public static Ray ViewportToRay(this Camera camera, Vector3 point)
        {
            var origin = ViewportToWorld(camera, new Vector3(point.x, point.y, 0));
            var target = ViewportToWorld(camera, new Vector3(point.x, point.y, 1));
            return new Ray(origin, target - origin);
        }

        public static Vector2 GetScreenSize()
        {
            Vector2 ViewSize;
#if UNITY_EDITOR
            System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
            System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            System.Object Res = GetSizeOfMainGameView.Invoke(null, null);
            ViewSize = (Vector2)Res;
#else
			ViewSize = new Vector2(Screen.width, Screen.height);
#endif
            return ViewSize;
        }
    }
}
