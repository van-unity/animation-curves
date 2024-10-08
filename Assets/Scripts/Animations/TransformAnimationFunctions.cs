using System;
using UnityEngine;

namespace Animations {
    public enum RotateMode {
        Fast, // Default rotation, shortest path
        WorldAxisAdd, // Add to the current world rotation (relative rotation in world space)
        LocalAxisAdd // Add to the current local rotation (relative rotation in local space)
    }

    public static class TransformAnimationFunctions {
        public static IAnimationJob ScaleTo(this Transform transform, Vector3 targetScale, float duration,
            AnimationCurve curve, Action onComplete = null) {
            var job = new ScaleAnimationJob(transform, targetScale, curve, duration, onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }

        public static IAnimationJob RotateToQuaternionLocal(this Transform transform, Quaternion rotation,
            float duration,
            AnimationCurve curve, Action onComplete = null) {
            var job = new RotationAnimationJob(transform, rotation, curve, duration, Space.Self, onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }

        public static IAnimationJob RotateToQuaternion(this Transform transform, Quaternion rotation, float duration,
            AnimationCurve curve, Action onComplete = null) {
            var job = new RotationAnimationJob(transform, rotation, curve, duration, Space.World, onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }
        
        public static IAnimationJob RotateTo(this Transform transform, Vector3 eulerAngles, float duration,
            AnimationCurve curve,
            RotateMode rotateMode = RotateMode.Fast,
            Action onComplete = null) {
            var job = new RotationEulerAnimationJob(transform, eulerAngles, curve, duration, Space.World, rotateMode,
                onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }
        
        public static IAnimationJob RotateToLocal(this Transform transform, Vector3 eulerAngles, float duration,
            AnimationCurve curve,
            RotateMode rotateMode = RotateMode.Fast,
            Action onComplete = null) {
            var job = new RotationEulerAnimationJob(transform, eulerAngles, curve, duration, Space.Self, rotateMode,
                onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }

        public static IAnimationJob MoveTo(this Transform transform, Vector3 position, float duration,
            AnimationCurve curve,
            Action onComplete = null) {
            var job = new PositionAnimationJob(transform, position, curve, duration, Space.World,
                onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }

        public static IAnimationJob MoveToLocal(this Transform transform, Vector3 position, float duration,
            AnimationCurve curve,
            Action onComplete = null) {
            var job = new PositionAnimationJob(transform, position, curve, duration, Space.Self,
                onComplete);

            AnimationManager.Instance.AddJob(job);

            return job;
        }
    }
}