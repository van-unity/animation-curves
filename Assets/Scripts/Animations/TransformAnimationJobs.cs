using System;
using UnityEngine;

namespace Animations {
    internal class ScaleAnimationJob : AnimationJob<Vector3> {
        private readonly Transform _target;

        public ScaleAnimationJob(Transform target, Vector3 endValue, AnimationCurve curve, float duration,
            Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
        }
        
        protected override Vector3 GetStartValue() {
            return _target.localScale;
        }
        
        protected override void SetValue(Vector3 value) {
            _target.localScale = value;
        }
    }

    internal class RotationAnimationJob : AnimationJob<Quaternion> {
        private readonly Transform _target;
        private readonly Space _space;

        public RotationAnimationJob(Transform target, Quaternion endValue, AnimationCurve curve, float duration,
            Space space = Space.World, Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
            _space = space;
        }
        
        protected override Quaternion GetStartValue() =>
            _space switch {
                Space.Self => _target.localRotation,
                _ => _target.rotation
            };
        
        protected override void SetValue(Quaternion value) {
            switch (_space) {
                case Space.Self:
                    _target.localRotation = value;
                    break;
                case Space.World:
                    _target.rotation = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class RotationEulerAnimationJob : AnimationJob<Vector3> {
        private readonly Transform _target;
        private readonly Space _space;
        private readonly RotateMode _rotateMode;
        private Vector3 _initialRotation;

        public RotationEulerAnimationJob(Transform target, Vector3 endValue, AnimationCurve curve, float duration,
            Space space = Space.World, RotateMode rotateMode = RotateMode.Fast, Action onComplete = null)
            : base(endValue, curve, duration, onComplete) {
            _target = target;
            _space = space;
            _rotateMode = rotateMode;
        }
        
        protected override Vector3 GetStartValue() {
            switch (_rotateMode) {
                case RotateMode.LocalAxisAdd:
                    _initialRotation = _target.localEulerAngles;
                    return _initialRotation; 
                case RotateMode.WorldAxisAdd:
                    _initialRotation = _target.eulerAngles;
                    return _initialRotation; 
                default: 
                    return _space == Space.Self ? _target.localEulerAngles : _target.eulerAngles; // Absolute rotation
            }
        }
        
        protected override void SetValue(Vector3 value) {
            Quaternion rotation;

            switch (_rotateMode) {
                case RotateMode.LocalAxisAdd:
                    rotation = Quaternion.Euler(_initialRotation + value);
                    _target.localRotation = rotation;
                    break;
                case RotateMode.WorldAxisAdd:
                    rotation = Quaternion.Euler(_initialRotation + value);
                    _target.rotation = rotation;
                    break;
                default: 
                    rotation = Quaternion.Euler(value);
                    if (_space == Space.Self) {
                        _target.localRotation = rotation;
                    } else {
                        _target.rotation = rotation;
                    }

                    break;
            }
        }
    }

    internal class PositionAnimationJob : AnimationJob<Vector3> {
        private readonly Transform _target;
        private readonly Space _space;

        public PositionAnimationJob(Transform target, Vector3 endValue, AnimationCurve curve, float duration,
            Space space = Space.World, Action onComplete = null) : base(endValue, curve, duration, onComplete) {
            _target = target;
            _space = space;
        }

        protected override Vector3 GetStartValue() =>
            _space switch {
                Space.Self => _target.localPosition,
                _ => _target.position
            };

        protected override void SetValue(Vector3 value) {
            switch (_space) {
                case Space.Self:
                    _target.localPosition = value;
                    break;
                case Space.World:
                    _target.position = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}