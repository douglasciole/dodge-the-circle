using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiateScript : MonoBehaviour
{
    public float ringSpeed;
    public bool instantiateFlag;

    public List<GameObject> arrayLevel_0, arrayLevel_1, arrayLevel_2, arrayLevel_3, arrayLevel_4, arrayLevel_5;
    public GameObject ringTest;

    private GameObject currentInstance;

    public Metronome metronomeScript;

    public int phase;
    public int maxPhase;
    public float gameTimer;
    public int maxPhaseTimer;

    void Start()
    {
        phase = 0;
        metronomeScript = this.GetComponent<Metronome>();
        arrayLevel_0 = PopulateInstantiateList(0);
        arrayLevel_1 = PopulateInstantiateList(1);
        arrayLevel_2 = PopulateInstantiateList(2);
        arrayLevel_3 = PopulateInstantiateList(2);
        arrayLevel_4 = PopulateInstantiateList(2);
        arrayLevel_5 = PopulateInstantiateList(2);
    }

    void FixedUpdate()
    {

        gameTimer += Time.deltaTime;

        if (phase < maxPhase)
        {
            if (gameTimer > (maxPhaseTimer / maxPhase) * (phase + 1))
            {
                phase++;
            }
        }


        if (metronomeScript.spawnRing)
        {
            metronomeScript.spawnRing = false;
            //Level selector
            GameObject tempObject = PickFromLevel(phase);
            currentInstance = GameObject.Instantiate(tempObject, Vector3.zero, Quaternion.identity);
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
            case 3:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_3.Count)];
                }
            case 4:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_4.Count)];
                }
            case 5:
                {
                    return arrayLevel_0[Random.Range(0, arrayLevel_5.Count)];
                }
            default:
                return ringTest;
        }
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