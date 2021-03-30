using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private float timerCounter;
    [SerializeField] private float timerTracker;
    [SerializeField] private AudioClip playingSong;
    [SerializeField] private float songBPM;
    [SerializeField] private float beatInterval;

    [SerializeField] private bool beatFlag;
    [SerializeField] private bool skipNext;
    public bool[] beatTempo;

    public bool spawnRing;

    void Start()
    {
        playingSong = GameObject.Find("GameAudioSource").GetComponent<AudioSource>().clip;
        songBPM = float.Parse(playingSong.name.Substring(0, 3).ToString());
        beatInterval = Mathf.Round((50 * 60) / songBPM);
        beatTempo = new bool[4] { true, false, false, false };
    }

    void FixedUpdate()
    {
        timerCounter++;
        timerTracker += Time.deltaTime;
        CheckForBeat();
        SpawnLogic();
    }

    void CheckForBeat()
    {
        if (timerCounter % beatInterval == 0)
        {
            NextTempo();
            if (beatTempo[1] == true || beatTempo[3] == true)
            {
                beatFlag = true;
            }
        }
    }

    void SpawnLogic()
    {
        if (beatFlag)
        {
            spawnRing = true;
            beatFlag = false;
        }
    }

    void NextTempo()
    {
        if (beatTempo[0])
        {
            beatTempo[0] = false;
            beatTempo[1] = true;
        }
        else if (beatTempo[1])
        {
            beatTempo[1] = false;
            beatTempo[2] = true;
        }
        else if (beatTempo[2])
        {
            beatTempo[2] = false;
            beatTempo[3] = true;
        }
        else if (beatTempo[3])
        {
            beatTempo[3] = false;
            beatTempo[0] = true;
        }

    }

}
