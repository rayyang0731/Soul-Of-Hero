using UnityEngine;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    public static class UIEffectHelper
    {
        #region Blur

        private static Shader _blurShader;
        private static Material _blurMat;

        public static Material BlurMaterial
        {
            get
            {
                if (_blurShader == null)
                    _blurShader = Shader.Find("Kiwi/UI/Default-Blur");
                if (_blurMat == null)
                {
                    _blurMat = new Material(_blurShader);
                    _blurMat.name = "Kiwi-UI-Blur";
                }

                return _blurMat;
            }
        }

        public static void SetBlur(Graphic target, bool value)
        {
            target.material = value ? BlurMaterial : null;
        }

        /// <summary>
        /// 释放UI模糊材质
        /// </summary>
        public static void ReleaseBlurMaterial()
        {
            _blurMat = null;
            _blurShader = null;
        }

        #endregion

        #region Gray

        private static Shader _grayShader;
        private static Material _grapMat;

        public static Material GrapMaterial
        {
            get
            {
                if (_grayShader == null)
                    _grayShader = Shader.Find("Kiwi/UI/Default-Gray");
                if (_grapMat == null)
                {
                    _grapMat = new Material(_grayShader);
                    _grapMat.name = "Kiwi-UI-Gray";
                }

                return _grapMat;
            }
        }

        public static void SetGray(Graphic target, bool value)
        {
            if (target != null)
                target.material = value ? GrapMaterial : null;
        }

        public static void SetGrayRecursion(GameObject go, bool value)
        {
            if (go == null)
                return;

            IGrayable[] targets = go.GetComponentsInChildren<IGrayable>();
            foreach (var target in targets)
            {
                target.SetGray(value);
            }
        }

        #endregion
    }
}