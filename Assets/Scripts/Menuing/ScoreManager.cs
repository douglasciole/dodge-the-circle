using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject hs_label;
    private string hs_string;

    private void Start()
    {
        string hs_string = HStoString(PlayerPrefs.GetInt("High_Score", 0));

        hs_label.GetComponent<Text>().text = hs_string;
        hs_label.transform.GetChild(0).GetComponent<Text>().text = hs_string;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("1_MenuScene", LoadSceneMode.Single);
    }

    string HStoString(int hs)
    {
        string hs_string;
        switch (hs)
        {
            case int n when (n < 10):
                hs_string = ("0000" + hs.ToString());
                break;
            case int n when (n < 100):
                hs_string = ("000" + hs.ToString());
                break;
            case int n when (n < 1000):
                hs_string = ("00" + hs.ToString());
                break;
            case int n when (n < 10000):
                hs_string = ("0" + hs.ToString());
                break;
            default:
                hs_string = hs.ToString();
                break;
        }
        return hs_string;
    }
}
