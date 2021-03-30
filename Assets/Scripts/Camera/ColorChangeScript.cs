using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public Material overlayMaterial;
    public Material spriteMaterial, spriteTrailMaterial;
    public Material playerMaterial, playerTrailMaterial, playerShieldMaterial;
    public Color referenceColor;
    public Color colorChangeTarget;
    public Color[] possibleTargets;

    public float colorChangeSpeed;
    public bool colorChangeInMotion;


    private void Start()
    {
        referenceColor = overlayMaterial.color;
        ColorSetter();
    }

    void FixedUpdate()
    {
        ColorLerp();
        ColorSetter();

    }
    void ColorLerp()
    {
        if (!colorChangeInMotion)
        {
            colorChangeInMotion = true;
            colorChangeTarget = possibleTargets[Random.Range(0, possibleTargets.Length - 1)];
        }
        else
        {
            referenceColor = Color.Lerp(referenceColor, colorChangeTarget, colorChangeSpeed);
            float diff = Vector4.Distance(referenceColor, colorChangeTarget);
            if (Mathf.Abs(diff) < 0.01f)
            {
                colorChangeInMotion = false;
            }
        }
    }
    void ColorSetter()
    {
        ColorSetter(true, true, true);
    }

    void ColorSetter(bool overlay, bool sprite, bool player)
    {
        if (overlay)
        {
            overlayMaterial.SetColor("_Color", referenceColor);
        }
        if (sprite)
        {
            spriteMaterial.SetColor("_Color", referenceColor);
            spriteMaterial.SetColor("_EmissionColor", referenceColor);
            Color trailMaterial = referenceColor;
            trailMaterial.a = .3f;
            spriteTrailMaterial.SetColor("_Color", trailMaterial);
        }
        if (player)
        {
            playerMaterial.SetColor("_Color", referenceColor);
            playerMaterial.SetColor("_EmissionColor", referenceColor);
            Color trailMaterial = referenceColor;
            trailMaterial.a = .8f;
            playerTrailMaterial.SetColor("_Color", trailMaterial);
            playerTrailMaterial.SetColor("_EmissionColor", trailMaterial * -1);
            trailMaterial.a = .5f;
            playerShieldMaterial.SetColor("_Color", trailMaterial);
            playerShieldMaterial.SetColor("_EmissionColor", trailMaterial * +2);
        }
    }
}