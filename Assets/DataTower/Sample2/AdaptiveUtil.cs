using UnityEngine;

namespace DataTower.Sample2
{
    public static class AdaptiveUtil
    {
        static float _iOSScale = 1f;
        static float _androidScale = 1f;

        public static void UpdateSceneScale(RectTransform bg)
        {
#if UNITY_IOS
            Bg.localScale = new Vector3(_iOSScale, _iOSScale, 1);
#elif UNITY_ANDROID
            bg.localScale = new Vector3(_androidScale, _androidScale, 1);
#endif
        }
    }
}