using System;
using UnityEngine;
using UnityEngine.UI;

namespace Animations {
    internal class SizeDeltaAnimationJob : AnimationJob<Vector2> {
        private readonly RectTransform _target;

        public SizeDeltaAnimationJob(RectTransform target, Vector2 endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override Vector2 GetStartValue() {
            return _target.sizeDelta;
        }
        
        protected override void SetValue(Vector2 value) {
            _target.sizeDelta = value;
        }
    }

    internal class AnchorPosYAnimationJob : AnimationJob<float> {
        private readonly RectTransform _target;

        public AnchorPosYAnimationJob(RectTransform target, float endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override float GetStartValue() {
            return _target.anchoredPosition.y;
        }
        
        protected override void SetValue(float value) {
            var anchoredPosition = _target.anchoredPosition;
            anchoredPosition.y = value;
            _target.anchoredPosition = anchoredPosition;
        }
    }

    internal class AnchorPosXAnimationJob : AnimationJob<float> {
        private readonly RectTransform _target;

        public AnchorPosXAnimationJob(RectTransform target, float endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override float GetStartValue() {
            return _target.anchoredPosition.x;
        }
        
        protected override void SetValue(float value) {
            var anchoredPosition = _target.anchoredPosition;
            anchoredPosition.x = value;
            _target.anchoredPosition = anchoredPosition;
        }
    }

    internal class AnchorPosAnimationJob : AnimationJob<Vector2> {
        private readonly RectTransform _target;

        public AnchorPosAnimationJob(RectTransform target, Vector2 endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override Vector2 GetStartValue() {
            return _target.anchoredPosition;
        }
        
        protected override void SetValue(Vector2 value) {
            _target.anchoredPosition = value;
        }
    }

    internal class GraphicColorAnimationJob : AnimationJob<Color> {
        private readonly Graphic _target;

        public GraphicColorAnimationJob(Graphic target, Color endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override Color GetStartValue() {
            return _target.color;
        }
        
        protected override void SetValue(Color value) {
            _target.color = value;
        }
    }
}