using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject hs_label, ls_label;
    private string hs_string, ls_string;

    private void Start()
    {
        // string ls_string = HStoString(PlayerPrefs.GetFloat("Last_Score", 0));
        ls_string = string.Format("0.00", PlayerPrefs.GetFloat("Last_Score", 0));
        ls_label.GetComponent<Text>().text = ls_string;
        ls_label.transform.GetChild(0).GetComponent<Text>().text = ls_string;

        // string hs_string = HStoString(PlayerPrefs.GetFloat("High_Score", 0));
        hs_string = string.Format("0.00", PlayerPrefs.GetFloat("High_Score", 0));
        hs_label.GetComponent<Text>().text = hs_string;
        hs_label.transform.GetChild(0).GetComponent<Text>().text = hs_string;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("1_MenuScene", LoadSceneMode.Single);
    }

    string HStoString(float hs)
    {
        string hs_string;
        switch (hs)
        {
            case float n when (n < 10):
                hs_string = ("0000" + hs.ToString());
                break;
            case float n when (n < 100):
                hs_string = ("000" + hs.ToString());
                break;
            case float n when (n < 1000):
                hs_string = ("00" + hs.ToString());
                break;
            case float n when (n < 10000):
                hs_string = ("0" + hs.ToString());
                break;
            default:
                hs_string = hs.ToString();
                break;
        }
        return hs_string;
    }
}
