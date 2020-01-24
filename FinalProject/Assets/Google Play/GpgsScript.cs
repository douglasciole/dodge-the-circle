using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GpgsScript : MonoBehaviour
{

    int points = 0;
    public Text pointsText;
    public string leaderBoard, acheievementIDs;

    public static GpgsScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    void Start()
    {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;

        //Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        LogIn();
    }

    /// <summary>
    /// Make Login and manage the succes or failure
    /// </summary>
    public void LogIn()
    {
        Social.Active.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Sucess");
            }
            else
            {
                Debug.Log("Login failed");
            }
        });
    }

    /// <summary>
    /// Shows Leaderboard
    /// </summary>
    public void OnShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void OnShowArchivements() {
        Social.ShowAchievementsUI();
    }

    /// <summary>
    /// Adds score to Leaderboard
    /// </summary>
    public void addScoreLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(points, leaderBoard, (bool success) =>
            {
                if (success)
                {
                    points = 0;
                    pointsText.text = "Points: " + points;

                }
                else
                {
                    Debug.Log("Update Score Fail");
                }
            });
        }
    }

    /// <summary>
    /// Log Out
    /// </summary>
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
}
