using System;
using UnityEngine;

namespace Animations {
    public interface IAnimationJob {
        bool Update(float deltaTime);
        void Initialize();
        void Stop(); // Stops the animation completely
        void Pause(bool paused); // Pauses or resumes the animation
    }
    
    internal abstract class AnimationJob<TValue> : IAnimationJob {
        private readonly AnimationCurve _curve;
        private readonly float _duration;
        private readonly Action _onComplete;
        private readonly TValue _endValue;
        private readonly Func<TValue, TValue, float, TValue> _interpolator;

        private TValue _startValue;
        private float _elapsedTime;
        private bool _isStopped;
        private bool _isPaused;

        protected AnimationJob(TValue endValue, AnimationCurve curve, float duration, Action onComplete = null) {
            _curve = curve;
            _duration = duration;
            _onComplete = onComplete;
            _endValue = endValue;
            _interpolator = InterpolatorFactory.GetInterpolator<TValue>();
        }

        public void Initialize() {
            _startValue = GetStartValue();
            _isStopped = false;
            _isPaused = false;
        }

        public bool Update(float deltaTime) {
            if (_isStopped) {
                return true;
            }

            if (_isPaused) {
                return false;
            }

            _elapsedTime += deltaTime;
            var t = Mathf.Clamp01(_elapsedTime / _duration);
            var curveValue = _curve.Evaluate(t);
            
            var newValue = _interpolator(_startValue, _endValue, curveValue);
            
            SetValue(newValue);

            if (_elapsedTime >= _duration) {
                SetValue(_endValue); 
                _onComplete?.Invoke();
                return true;
            }

            return false; 
        }
        
        public void Stop() {
            _isStopped = true; 
        }
        
        public void Pause(bool paused) {
            _isPaused = paused;
        }

        protected abstract TValue GetStartValue();
        protected abstract void SetValue(TValue value);
    }
}