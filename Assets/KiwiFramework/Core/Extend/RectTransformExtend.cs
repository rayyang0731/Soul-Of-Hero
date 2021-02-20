using UnityEngine;

namespace KiwiFramework.Core
{
    public enum AnchorHorizontal
    {
        Left,
        Center,
        Right,
        Stretch
    }

    public enum AnchorVertical
    {
        Top,
        Middle,
        Bottom,
        Stretch
    }

    public static partial class Extend
    {
        public static void ResetZero(this RectTransform rectTransform, AnchorHorizontal horizontal,
            AnchorVertical vertical, Transform parent = null)
        {
            SetAnchorPresets(rectTransform, horizontal, vertical);
            if (parent != null)
                rectTransform.SetParent(parent);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.pivot = Vector2.one * 0.5f;
        }

        public static void SetAnchorPresets(this RectTransform rectTransform, AnchorHorizontal horizontal,
            AnchorVertical vertical)
        {
            Vector2 min = rectTransform.anchorMin;
            Vector2 max = rectTransform.anchorMax;

            Vector2 anchorHor = GetAnchorHorizontalValue(horizontal);
            min.x = anchorHor.x;
            max.x = anchorHor.y;

            Vector2 anchorVer = GetAnchorVerticalValue(vertical);
            min.y = anchorVer.x;
            max.y = anchorVer.y;

            rectTransform.anchorMin = min;
            rectTransform.anchorMax = max;

            rectTransform.pivot = new Vector2(min.x, max.y);
        }

        public static void SetAnchorHorizontal(this RectTransform rectTransform, AnchorHorizontal horizontal)
        {
            Vector2 min = rectTransform.anchorMin;
            Vector2 max = rectTransform.anchorMax;
            Vector2 anchor = GetAnchorHorizontalValue(horizontal);
            min.x = anchor.x;
            max.x = anchor.y;
            rectTransform.anchorMin = min;
            rectTransform.anchorMax = max;

            rectTransform.pivot = anchor;
        }

        public static void SetAnchorVertical(this RectTransform rectTransform, AnchorVertical vertical)
        {
            Vector2 min = rectTransform.anchorMin;
            Vector2 max = rectTransform.anchorMax;
            Vector2 anchor = GetAnchorVerticalValue(vertical);
            min.x = anchor.x;
            max.x = anchor.y;
            rectTransform.anchorMin = min;
            rectTransform.anchorMax = max;

            rectTransform.pivot = anchor;
        }

        public static Vector2 GetAnchorHorizontalValue(AnchorHorizontal horizontal)
        {
            switch (horizontal)
            {
                case AnchorHorizontal.Center:
                    return Vector2.one * 0.5f;
                case AnchorHorizontal.Left:
                    return Vector2.zero;
                case AnchorHorizontal.Right:
                    return Vector2.one;
                case AnchorHorizontal.Stretch:
                    return Vector2.up;
                default:
                    return Vector2.one * 0.5f;
            }
        }

        public static Vector2 GetAnchorVerticalValue(AnchorVertical vertical)
        {
            switch (vertical)
            {
                case AnchorVertical.Middle:
                    return Vector2.one * 0.5f;
                case AnchorVertical.Top:
                    return Vector2.one;
                case AnchorVertical.Bottom:
                    return Vector2.zero;
                case AnchorVertical.Stretch:
                    return Vector2.up;
                default:
                    return Vector2.one * 0.5f;
            }
        }

        public static bool IsAnchorPresets(this RectTransform rectTransform, AnchorHorizontal horizontal,
            AnchorVertical vertical)
        {
            return IsAnchorHorizontal(rectTransform, horizontal) && IsAnchorVertical(rectTransform, vertical);
        }

        public static bool IsAnchorHorizontal(this RectTransform rectTransform, AnchorHorizontal horizontal)
        {
            Vector2 anchor = GetAnchorHorizontalValue(horizontal);
            return rectTransform.anchorMin.x == anchor.x && rectTransform.anchorMax.x == anchor.y;
        }

        public static bool IsAnchorVertical(this RectTransform rectTransform, AnchorVertical vertical)
        {
            Vector2 anchor = GetAnchorVerticalValue(vertical);
            return rectTransform.anchorMin.y == anchor.x && rectTransform.anchorMax.y == anchor.y;
        }

        public static float GetWidth(this RectTransform rectTransform)
        {
            return rectTransform.rect.width;
        }

        public static float GetHeight(this RectTransform rectTransform)
        {
            return rectTransform.rect.height;
        }

        public static Vector2 GetSize(this RectTransform rectTransform)
        {
            return rectTransform.rect.size;
        }

        public static void SetWidth(this RectTransform rectTransform, float width)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        public static void SetHeight(this RectTransform rectTransform, float height)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        public static void SetSize(this RectTransform rectTransform, float width, float height)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        public static void SetSize(this RectTransform rectTransform, Vector2 size)
        {
            rectTransform.SetSize(size.x, size.y);
        }
    }
}