using UnityEngine;
using UnityEngine.UI;

namespace DataTower.Sample2
{
    public static class AdaptiveUtil
    {
        static float _iOSScale = 0.8f;
        static float _androidScale = 1f;

        public static void UpdateSceneScale(RectTransform bg)
        {
            // #if UNITY_IOS
            //             bg.localScale = new Vector3(_iOSScale, _iOSScale, 1);
            // #elif UNITY_ANDROID
            //             bg.localScale = new Vector3(_androidScale, _androidScale, 1);
            // #endif
        }

        public static void UpdateCanvasScale(CanvasScaler bg)
        {
#if UNITY_IOS
            bg.scaleFactor = _iOSScale;
#elif UNITY_ANDROID
            bg.scaleFactor = _androidScale;
#endif
        }
    }
}