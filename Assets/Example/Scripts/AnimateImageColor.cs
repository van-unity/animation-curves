using System;
using System.Collections;
using System.Collections.Generic;
using Animations;
using UnityEngine;
using UnityEngine.UI;

public class AnimateImageColor : MonoBehaviour {
    public Image image;
    public Color color;
    public AnimationCurve curve;
    public float duration = 5;

    private IEnumerator Start() {
        yield return new WaitForSeconds(1);

        image.ColorTo(color, duration, curve);
    }
}