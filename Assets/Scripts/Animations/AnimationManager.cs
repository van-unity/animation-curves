using System.Collections.Generic;
using UnityEngine;

namespace Animations {
    internal class AnimationManager : MonoBehaviour {
        public static AnimationManager Instance { get; private set; }

        private readonly List<IAnimationJob> _activeJobs = new List<IAnimationJob>();

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }

        private void Update() {
            for (int i = _activeJobs.Count - 1; i >= 0; i--) {
                var job = _activeJobs[i];

                if (job.Update(Time.deltaTime)) {
                    _activeJobs.RemoveAt(i);
                }
            }
        }
        
        public void AddJob(IAnimationJob job) {
            job.Initialize();
            _activeJobs.Add(job);
        }
    }
}