using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 按钮缩放数据类
    /// </summary>
    [Serializable]
    public class UIScaleHelper
    {
        [SerializeField, HideInInspector] private RectTransform _rectTransform;

        [SerializeField, ReadOnly] [DisplayAsString, VerticalGroup("btnScale")] [LabelText("缩放动画ID")]
        private int tweenId;

        [SerializeField, VerticalGroup("btnScale"), LabelText("动画曲线")]
        private Ease scaleAnimation = Ease.Linear;

        [SerializeField, VerticalGroup("btnScale"), LabelText("动画时长")]
        private float duration = 0.02f;

        [SerializeField, VerticalGroup("btnScale"), LabelText("缩放比例")]
        private Vector3 scaleRatio = new Vector3(0.9f, 0.9f, 0.9f);

        [SerializeField, HideInInspector] private Vector3 _originalScale;

        public UIScaleHelper(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
            tweenId = _rectTransform.GetHashCode();
            _originalScale = _rectTransform.localScale;
        }

        /// <summary>
        /// 执行缩放
        /// </summary>
        public void Execute()
        {
            DOTween.Kill(tweenId);
            var targetScale = _originalScale;
            targetScale.Scale(scaleRatio);
            _rectTransform.DOScale(targetScale, duration).SetEase(scaleAnimation).SetId(tweenId);
        }

        /// <summary>
        /// 重置缩放
        /// </summary>
        public void Rest(bool force = false)
        {
            DOTween.Kill(tweenId);
            if (!force)
                _rectTransform.DOScale(_originalScale, duration).SetEase(scaleAnimation).SetId(tweenId);
            else
                _rectTransform.localScale = _originalScale;
        }
    }
}