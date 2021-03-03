using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;

    public List<GameObject> arrayLevel_0;
    public List<GameObject> arrayLevel_1;
    public List<GameObject> arrayLevel_2;
    public GameObject ringTest;

    private GameObject currentInstance;

    public Metronome metronomeScript;

    public int phase;

    void Start()
    {
        phase = 0;
        metronomeScript = this.GetComponent<Metronome>();
        arrayLevel_0 = PopulateInstantiateList(0);
        arrayLevel_1 = PopulateInstantiateList(1);
        arrayLevel_2 = PopulateInstantiateList(2);
    }

    void FixedUpdate()
    {

        if (metronomeScript.spawnRing)
        {
            instantiateFlag = true;
            metronomeScript.spawnRing = false;
        }

        if (instantiateFlag)
        {
            //Level selector
            GameObject tempObject = PickFromLevel(phase);

            //instantiating tempObject
            currentInstance = GameObject.Instantiate(tempObject, Vector3.zero, Quaternion.identity);
            // Rotate on create
            // currentInstance.GetComponent<RotationScript>().rotationSpeed = 0;
            // currentInstance.GetComponent<RotationScript>().randomInitial = false;

            instantiateFlag = false;
        }
    }

    GameObject PickFromLevel(int level)
    {
        switch (level)
        {
            case 0:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_0.Count)];
                }
            case 1:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_1.Count)];
                }
            case 2:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_2.Count)];
                }
            default:
                return ringTest;
        }
    }

    public void spawnRing()
    {
        instantiateFlag = true;
    }

    public List<GameObject> PopulateInstantiateList(int inputLevel)
    {

        List<GameObject> returnArray = new List<GameObject>();

        foreach (GameObject gameObject in Resources.LoadAll("Level" + inputLevel))
        {
            returnArray.Add(gameObject);
        }

        return returnArray;
    }


}