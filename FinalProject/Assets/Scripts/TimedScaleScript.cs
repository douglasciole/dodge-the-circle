using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedScaleScript : MonoBehaviour
{
    public float scaleSpeed;
    public int maxSize;

    public Vector3 initialScale;
    public RingInstantiateScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = initialScale;
        gameManagerScript = GameObject.FindWithTag("Game Manager").GetComponent<RingInstantiateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        scaleSpeed = gameManagerScript.ringSpeed;
        this.transform.localScale = this.transform.localScale + new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, 0);

        if(this.transform.localScale.x > maxSize){
            Destroy(gameObject);
        }
    }
}
