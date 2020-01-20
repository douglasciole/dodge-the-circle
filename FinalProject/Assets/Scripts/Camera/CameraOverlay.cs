using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverlay : MonoBehaviour
{
    public Material overlayMaterial;
    public Color materialColor;
    public Color colorChangeTarget;

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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorChanger();
    }

    void FixedUpdate() {
        colorChangeCounter++;
    }

    void ColorChanger(){
        if(colorChangeCounter > colorChangeThreshold && !colorChangeInMotion){
            colorChangeInMotion = true;
            colorChangeTarget = new Color(Random.RandomRange(RMin, RMax),Random.RandomRange(GMin, GMax),Random.RandomRange(BMin, BMax),0.5f);
        }

        if(colorChangeInMotion){

            materialColor = Color.Lerp(materialColor,colorChangeTarget ,colorChangeSpeed);
            
            float diff = Vector4.Distance(materialColor,colorChangeTarget);
            
            if(Mathf.Abs(diff) < 0.01f){
                colorChangeInMotion = false;
                colorChangeCounter = 0;
            }
        }
    overlayMaterial.SetColor("_Color", materialColor);
    }

}
