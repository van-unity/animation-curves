using System;
using UnityEngine;

namespace Animations {
    internal static class InterpolatorFactory {
        public static Func<T, T, float, T> GetInterpolator<T>() =>
            typeof(T) switch {
                _ when typeof(T) == typeof(float) => (Func<T, T, float, T>)(object)(Func<float, float, float, float>)
                    Mathf
                        .LerpUnclamped,
                _ when typeof(T) == typeof(Vector2) => (Func<T, T, float, T>)
                    (object)(Func<Vector2, Vector2, float, Vector2>)Vector2.LerpUnclamped,
                _ when typeof(T) == typeof(Vector3) => (Func<T, T, float, T>)
                    (object)(Func<Vector3, Vector3, float, Vector3>)Vector3.LerpUnclamped,
                _ when typeof(T) == typeof(Vector4) => (Func<T, T, float, T>)
                    (object)(Func<Vector4, Vector4, float, Vector4>)Vector4.LerpUnclamped,
                _ when typeof(T) == typeof(Quaternion) => (Func<T, T, float, T>)
                    (object)(Func<Quaternion, Quaternion, float, Quaternion>)Quaternion.LerpUnclamped,
                _ when typeof(T) == typeof(Color) => (Func<T, T, float, T>)(object)(Func<Color, Color, float, Color>)
                    Color
                        .LerpUnclamped,

                _ => throw new InvalidOperationException($"No interpolator found for type {typeof(T)}")
            };
    }
}