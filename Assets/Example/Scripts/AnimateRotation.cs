using System;
using System.Collections;
using System.Collections.Generic;
using Animations;
using UnityEngine;

public class AnimateRotation : MonoBehaviour {
    public Transform targetTransform;
    public Vector3 angles;
    public RotateMode mode;
    public AnimationCurve curve;
    public float duration = 5;

    private IEnumerator Start() {
        yield return new WaitForSeconds(1);

        targetTransform.RotateTo(angles, duration, curve, mode);
    }
}
