using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverlay : MonoBehaviour
{
    public Material overlayMaterial;
    public Color materialColor;
    public Color colorChangeTarget;
    public Color[] possibleTargets;

    public int colorChangeCounterStart;
    public int colorChangeStartThreshold;
    public float colorChangeCounter;
    public float colorChangeThreshold;
    public float colorChangeSpeed;
    public bool colorChangeInMotion;

    void FixedUpdate()
    {
        colorChangeCounter++;
        colorChangeCounterStart++;
        overlayMaterial.SetColor("_Color", materialColor);
        if (colorChangeCounterStart > colorChangeStartThreshold)
        {
            ColorChangerBG();
        }
    }
    void ColorChangerBG()
    {
        if (colorChangeCounter > colorChangeThreshold && !colorChangeInMotion)
        {
            colorChangeInMotion = true;
            colorChangeTarget = possibleTargets[Random.Range(0, possibleTargets.Length - 1)];
        }
        if (colorChangeInMotion)
        {
            materialColor = Color.Lerp(materialColor, colorChangeTarget, colorChangeSpeed);
            float diff = Vector4.Distance(materialColor, colorChangeTarget);
            if (Mathf.Abs(diff) < 0.01f)
            {
                colorChangeInMotion = false;
            }
        }
    }
}