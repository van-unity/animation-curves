using System;
using UnityEngine;
using UnityEngine.UI;

namespace Animations {
    public static class UiAnimationFunctions {
        public static IAnimationJob SizeTo(this RectTransform rectTransform, Vector2 targetSize, float duration,
            AnimationCurve curve, Action onComplete = null) {
            
            var job = new SizeDeltaAnimationJob(rectTransform, targetSize, curve, duration, onComplete);
            
            AnimationManager.Instance.AddJob(job);
            return job;
        }

        public static IAnimationJob MoveAnchorPosX(this RectTransform rectTransform, float targetX, float duration,
            AnimationCurve curve, Action onComplete = null) {
            
            var job = new AnchorPosXAnimationJob(rectTransform, targetX, curve, duration, onComplete);
            
            AnimationManager.Instance.AddJob(job);
            return job;
        }
        
        public static IAnimationJob MoveAnchorPosY(this RectTransform rectTransform, float targetY, float duration,
            AnimationCurve curve, Action onComplete = null) {
            
            var job = new AnchorPosYAnimationJob(rectTransform, targetY, curve, duration, onComplete);
            
            AnimationManager.Instance.AddJob(job);
            return job;
        }
        
        public static IAnimationJob MoveAnchorPos(this RectTransform rectTransform, Vector2 targetPosition,
            float duration, AnimationCurve curve, Action onComplete = null) {
            var job = new AnchorPosAnimationJob(rectTransform, targetPosition, curve, duration, onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }
        
        public static IAnimationJob ColorTo(this Graphic graphic, Color targetColor, float duration,
            AnimationCurve curve, Action onComplete = null) {
            var job = new GraphicColorAnimationJob(graphic, targetColor, curve, duration, onComplete);
            AnimationManager.Instance.AddJob(job);
            return job;
        }
    }
}