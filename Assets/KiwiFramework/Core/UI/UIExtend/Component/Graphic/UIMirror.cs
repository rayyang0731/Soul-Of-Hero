using System.Collections.Generic;
using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    [ShowOdinSerializedPropertiesInInspector]
    public class UIMirror : Image
    {
        /// <summary>
        /// 镜像类型
        /// </summary>
        public enum MIRROR_TYPE
        {
            /// <summary>
            /// 水平镜像
            /// </summary>
            HORIZONTAL,

            /// <summary>
            /// 垂直镜像
            /// </summary>
            VERTICAL,

            /// <summary>
            /// 万花筒(四分之一图片)
            /// </summary>
            QUARTER
        }

        #region Editor

#if UNITY_EDITOR

#endif

        #endregion

        #region Private Variables

        private MIRROR_TYPE _mirrorType;

        private List<UIVertex> _vertexs = new List<UIVertex>();

        #endregion

        #region Public Variables

        #endregion

        #region Private Properties

        #endregion

        #region Public Properties

        /// <summary>
        /// 镜像类型
        /// </summary>
        public MIRROR_TYPE MirrorType
        {
            get { return _mirrorType; }
            set
            {
                if (!SetPropertyUtil.SetStruct(ref _mirrorType, value))
                    return;
                this.SetVerticesDirty();
            }
        }

        #endregion

        #region Pirvate Methods

        /// <summary>
        /// Simple模式,原始图片顶点左移
        /// </summary>
        /// <param name="rect">像素矫正过的尺寸(排除图片的 alpha 区域)</param>
        /// <param name="verts">原始的顶点数据</param>
        /// <param name="count">原始顶点数量</param>
        private void SimpleScale(Rect rect, List<UIVertex> verts, int count)
        {
            for (int i = 0; i < count; i++)
            {
                UIVertex vertex = verts[i];
                Vector3 position = vertex.position;
                if (MirrorType == MIRROR_TYPE.HORIZONTAL || MirrorType == MIRROR_TYPE.QUARTER)
                    position.x = (position.x + rect.x) * 0.5f;
                if (MirrorType == MIRROR_TYPE.VERTICAL || MirrorType == MIRROR_TYPE.QUARTER)
                    position.y = (position.y + rect.y) * 0.5f;
                vertex.position = position;
                verts[i] = vertex;
            }
        }

        /// <summary>
        /// Sliced模式,原始图片顶点左移
        /// </summary>
        /// <param name="rect">像素矫正过的尺寸(排除图片的 alpha 区域)</param>
        /// <param name="verts">原始的顶点数据</param>
        /// <param name="count">原始顶点数量</param>
        private void SlicedScale(Rect rect, List<UIVertex> verts, int count)
        {
            Vector4 border = GetAdjustedBorders(rect);
            float halfWidth = rect.width * 0.5f;
            float halfHeight = rect.height * 0.5f;
            for (int i = 0; i < count; i++)
            {
                UIVertex vertex = verts[i];
                Vector3 position = vertex.position;
                if (MirrorType == MIRROR_TYPE.HORIZONTAL || MirrorType == MIRROR_TYPE.QUARTER)
                {
                    if (halfWidth < border.x && position.x >= rect.center.x)
                        position.x = rect.center.x;
                    else if (position.x >= border.x)
                        position.x = (position.x + rect.x) * 0.5f;
                }

                if (MirrorType == MIRROR_TYPE.VERTICAL || MirrorType == MIRROR_TYPE.QUARTER)
                {
                    if (halfHeight < border.y && position.y >= rect.center.y)
                        position.y = rect.center.y;
                    else if (position.y >= border.y)
                        position.y = (position.y + rect.y) * 0.5f;
                }

                vertex.position = position;
                verts[i] = vertex;
            }
        }

        /// <summary>
        /// 返回Sprite切片区域
        /// (Copy From Image.GetAdjustedBorders)
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Vector4 GetAdjustedBorders(Rect rect)
        {
            Vector4 border = sprite.border;

            border /= pixelsPerUnit;

            for (int axis = 0; axis <= 1; axis++)
            {
                float combinedBorders = border[axis] + border[axis + 2];
                if (rect.size[axis] < combinedBorders && combinedBorders != 0)
                {
                    float borderScaleRatio = rect.size[axis] / combinedBorders;
                    border[axis] *= borderScaleRatio;
                    border[axis + 2] *= borderScaleRatio;
                }
            }

            return border;
        }

        /// <summary>
        /// 清理掉不能成三角面的顶点
        /// 判断三个顶点是否有重合，把无用的三角面挪到数组最后，
        /// 在遍历完之后，把结尾的无用三角面删掉
        /// </summary>
        /// <param name="verts">顶点数据</param>
        /// <param name="count">顶点数量</param>
        /// <returns>实际可用的顶点数量</returns>
        private int SliceExcludeVerts(List<UIVertex> verts, int count)
        {
            int realCount = count;

            int i = 0;

            while (i < realCount)
            {
                UIVertex v1 = verts[i];
                UIVertex v2 = verts[i + 1];
                UIVertex v3 = verts[i + 2];

                if (v1.position == v2.position || v2.position == v3.position || v3.position == v1.position)
                {
                    verts[i] = verts[realCount - 3];
                    verts[i + 1] = verts[realCount - 2];
                    verts[i + 2] = verts[realCount - 1];

                    realCount -= 3;
                    continue;
                }

                i += 3;
            }

            if (realCount < count)
                verts.RemoveRange(realCount, count - realCount);

            return realCount;
        }


        /// <summary>
        /// 扩展容量(镜像图片的顶点)
        /// </summary>
        /// <param name="verts">顶点数据</param>
        /// <param name="addCount">要添加的数量</param>
        private void ExtendCapacity(List<UIVertex> verts, int addCount)
        {
            var neededCapacity = verts.Count + addCount;
            if (verts.Capacity < neededCapacity)
                verts.Capacity = neededCapacity;
        }

        /// <summary>
        /// 计算镜像顶点
        /// </summary>
        /// <param name="rect">像素矫正过的尺寸(排除图片的 alpha 区域)</param>
        /// <param name="verts">顶点数据</param>
        /// <param name="count">镜像顶点数量</param>
        /// <param name="isHorizontal">是否是水平镜像</param>
        private void MirrorVerts(Rect rect, List<UIVertex> verts, int count, bool isHorizontal = true)
        {
            for (int i = 0; i < count; i++)
            {
                UIVertex vertex = verts[i];
                Vector3 position = vertex.position;
                if (isHorizontal)
                    position.x = rect.center.x * 2 - position.x;
                else
                    position.y = rect.center.y * 2 - position.y;
                vertex.position = position;
                verts.Add(vertex);
            }
        }

        /// <summary>
        /// 返回三个点的中心点
        /// </summary>
        /// <returns></returns>
        protected float GetCenter(float p1, float p2, float p3)
        {
            float max = Mathf.Max(Mathf.Max(p1, p2), p3);
            float min = Mathf.Min(Mathf.Min(p1, p2), p3);
            return (max + min) / 2;
        }

        /// <summary>
        /// 返回翻转UV坐标
        /// </summary>
        /// <param name="uv">原始 UV 坐标</param>
        /// <param name="start">起始值</param>
        /// <param name="length">长度</param>
        /// <param name="isHorizontal">是否是水平翻转</param>
        /// <returns></returns>
        private Vector2 GetOverturnUV(Vector2 uv, float start, float length, bool isHorizontal = true)
        {
            if (isHorizontal)
                uv.x = length - uv.x + start;
            else
                uv.y = length - uv.y + start;

            return uv;
        }

        private void DrawSimple(List<UIVertex> vertexs, int count)
        {
            Rect rect = GetPixelAdjustedRect();
            SimpleScale(rect, vertexs, count);

            switch (MirrorType)
            {
                case MIRROR_TYPE.HORIZONTAL:
                    ExtendCapacity(vertexs, count);
                    MirrorVerts(rect, vertexs, count, true);
                    break;
                case MIRROR_TYPE.VERTICAL:
                    ExtendCapacity(vertexs, count);
                    MirrorVerts(rect, vertexs, count, false);
                    break;
                case MIRROR_TYPE.QUARTER:
                    ExtendCapacity(vertexs, count * 3);
                    MirrorVerts(rect, vertexs, count, true);
                    MirrorVerts(rect, vertexs, count * 2, false);
                    break;
            }
        }

        private void DrawSliced(List<UIVertex> vertexs, int count)
        {
            if (!hasBorder)
            {
                DrawSimple(vertexs, count);
                return;
            }

            Rect rect = GetPixelAdjustedRect();

            SlicedScale(rect, vertexs, count);

            count = SliceExcludeVerts(vertexs, count);

            switch (MirrorType)
            {
                case MIRROR_TYPE.HORIZONTAL:
                    ExtendCapacity(vertexs, count);
                    MirrorVerts(rect, vertexs, count, true);
                    break;
                case MIRROR_TYPE.VERTICAL:
                    ExtendCapacity(vertexs, count);
                    MirrorVerts(rect, vertexs, count, false);
                    break;
                case MIRROR_TYPE.QUARTER:
                    ExtendCapacity(vertexs, count * 3);
                    MirrorVerts(rect, vertexs, count, true);
                    MirrorVerts(rect, vertexs, count * 2, false);
                    break;
            }
        }

        private void DrawTiled(List<UIVertex> verts, int count)
        {
            Rect rect = GetPixelAdjustedRect();

            //此处使用inner是因为Image绘制Tiled时，会把透明区域也绘制了。

            Vector4 inner = DataUtility.GetInnerUV(sprite);

            float w = sprite.rect.width / pixelsPerUnit;
            float h = sprite.rect.height / pixelsPerUnit;

            int len = count / 3;

            for (int i = 0; i < len; i++)
            {
                UIVertex v1 = verts[i * 3];
                UIVertex v2 = verts[i * 3 + 1];
                UIVertex v3 = verts[i * 3 + 2];

                float centerX = GetCenter(v1.position.x, v2.position.x, v3.position.x);
                float centerY = GetCenter(v1.position.y, v2.position.y, v3.position.y);

                if (MirrorType == MIRROR_TYPE.HORIZONTAL || MirrorType == MIRROR_TYPE.QUARTER)
                {
                    //判断三个点的水平位置是否在偶数矩形内，如果是，则把UV坐标水平翻转
                    if (Mathf.FloorToInt((centerX - rect.xMin) / w) % 2 == 1)
                    {
                        v1.uv0 = GetOverturnUV(v1.uv0, inner.x, inner.z, true);
                        v2.uv0 = GetOverturnUV(v2.uv0, inner.x, inner.z, true);
                        v3.uv0 = GetOverturnUV(v3.uv0, inner.x, inner.z, true);
                    }
                }

                if (MirrorType == MIRROR_TYPE.VERTICAL || MirrorType == MIRROR_TYPE.QUARTER)
                {
                    //判断三个点的垂直位置是否在偶数矩形内，如果是，则把UV坐标垂直翻转
                    if (Mathf.FloorToInt((centerY - rect.yMin) / h) % 2 == 1)
                    {
                        v1.uv0 = GetOverturnUV(v1.uv0, inner.y, inner.w, false);
                        v2.uv0 = GetOverturnUV(v2.uv0, inner.y, inner.w, false);
                        v3.uv0 = GetOverturnUV(v3.uv0, inner.y, inner.w, false);
                    }
                }

                verts[i * 3] = v1;
                verts[i * 3 + 1] = v2;
                verts[i * 3 + 2] = v3;
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Unity Methods

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            base.OnPopulateMesh(vh);
            if (sprite == null || !isActiveAndEnabled)
                return;

            vh.GetUIVertexStream(_vertexs);

            int count = _vertexs.Count;

            switch (type)
            {
                case Type.Simple:
                    DrawSimple(_vertexs, count);
                    break;
                case Type.Sliced:
                    DrawSliced(_vertexs, count);
                    break;
                case Type.Tiled:
                    DrawTiled(_vertexs, count);
                    break;
            }

            vh.Clear();
            vh.AddUIVertexTriangleStream(_vertexs);
            _vertexs.Clear();
        }

        /// <summary>
        /// 使用图片原始尺寸
        /// </summary>
        public override void SetNativeSize()
        {
            if (sprite != null)
            {
                var rt = rectTransform;
                float w = sprite.rect.width / pixelsPerUnit;
                float h = sprite.rect.height / pixelsPerUnit;
                rt.anchorMax = rt.anchorMin;

                switch (MirrorType)
                {
                    case MIRROR_TYPE.HORIZONTAL:
                        rt.sizeDelta = new Vector2(w * 2, h);
                        break;
                    case MIRROR_TYPE.VERTICAL:
                        rt.sizeDelta = new Vector2(w, h * 2);
                        break;
                    case MIRROR_TYPE.QUARTER:
                        rt.sizeDelta = new Vector2(w * 2, h * 2);
                        break;
                }

                SetVerticesDirty();
            }
        }

        #endregion
    }
}