using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverlay : MonoBehaviour
{
    public Material overlayMaterial;
    public Color materialColor;
    public Color colorChangeTarget;

    public int colorChangeCounterStart;
    public int colorChangeStartThreshold;
    public float colorChangeCounter;
    public float colorChangeThreshold;
    public float RMax;
    public float RMin;
    public float GMax;
    public float GMin;
    public float BMax;
    public float BMin;
    public float colorChangeSpeed;
    public bool colorChangeInMotion;

    void FixedUpdate()
    {
        colorChangeCounter++;
        colorChangeCounterStart++; overlayMaterial.SetColor("_Color", materialColor);
        if (colorChangeCounterStart > colorChangeStartThreshold) { ColorChanger(); }
    }
    void ColorChanger()
    {
        if (colorChangeCounter > colorChangeThreshold && !colorChangeInMotion)
        {
            colorChangeInMotion = true;
            colorChangeTarget = new Color(Random.Range(RMin, RMax), Random.Range(GMin, GMax), Random.Range(BMin, BMax), 1f);
        }
        if (colorChangeInMotion)
        {
            materialColor = Color.Lerp(materialColor, colorChangeTarget, colorChangeSpeed);
            float diff = Vector4.Distance(materialColor, colorChangeTarget);
            if (Mathf.Abs(diff) < 0.01f)
            {
                colorChangeInMotion = false;
                colorChangeCounter = 0;
            }
        }
    }
}