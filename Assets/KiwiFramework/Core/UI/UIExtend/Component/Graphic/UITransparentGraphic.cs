using UnityEngine;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 透明图片
    /// </summary>
    [AddComponentMenu("KiwiUI/Graphic/TransparentGrphic")]
    public class UITransparentGraphic : Graphic
    {
        /// <summary>
        /// 射线碰撞只能为true,不可以关闭
        /// </summary>
        public override bool raycastTarget => true;

        protected UITransparentGraphic()
        {
            this.useLegacyMeshGeneration = false;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                vh.Clear();
            }
            else
            {
                var r = GetPixelAdjustedRect();
                var v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);

                Color32 color32 = color;
                color32.a = 128;
                vh.Clear();
                vh.AddVert(new Vector3(v.x, v.y), color32, Vector2.zero);
                vh.AddVert(new Vector3(v.x, v.w), color32, Vector2.up);
                vh.AddVert(new Vector3(v.z, v.w), color32, Vector2.one);
                vh.AddVert(new Vector3(v.z, v.y), color32, Vector2.right);

                vh.AddTriangle(0, 1, 2);
                vh.AddTriangle(2, 3, 0);
            }
#else
            vh.Clear();
#endif
        }
    }
}