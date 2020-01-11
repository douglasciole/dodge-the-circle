using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;
    public GameObject ringPrefab;
    private GameObject currentInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(instantiateFlag){
            currentInstance = GameObject.Instantiate(ringPrefab,Vector3.zero,Quaternion.identity);

            currentInstance.transform.RotateAroundLocal(Vector3.forward, Random.Range(-180,180));
            instantiateFlag = false;
        }
    }
}
