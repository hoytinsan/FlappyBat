using System;
using Unity.Services.Analytics;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region Properties

    public bool IsButtonPressEnabled;
    public bool HasPlayerAuthenticated;
    public int HighScore;
    public bool RemoveAds;
    public string UserName; 

    #endregion

    #region Singleton Pattern

    private static GameData _current;

    public static GameData Current
    {
         get { return _current ?? (_current = (GameData) FindObjectOfType(typeof (GameData))); }
    }

    #endregion

    void Awake()
    {
        Application.targetFrameRate = 60;
        LogManager.Initiliaze();
        IsButtonPressEnabled = true;
        HighScore = GetHighScore();
        RemoveAds =  GetRemoveAds();
        //UserName = GetUserName();
    }

    void Start()
    {
        //if (UserName.Equals(""))
        //{
        //    UIEventManager.Current.LoadUserName();
        //}
        //else
        {
            UIEventManager.Current.LoadVampire();
        }
    }

    #region Setters & Getters

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public string GetUserName()
    {
        return PlayerPrefs.GetString("UserName", "");
    }

    public bool GetRemoveAds()
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt("RemoveAds", 0));
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        HighScore = score;
        AnalyticsSystem.Current.RecordHighScore(score);
        GooglePlayGamesManager.Current.SendScore(score);
        PlayerPrefs.Save();
    }

    public void SetUserName(string username)
    {
        UserName = username;
    }

    public void SaveUserName( )
    {
        PlayerPrefs.SetString("UserName", UserName);
        PlayerPrefs.Save();
    }

    public void SetRemoveAds(int remove)
    {
        RemoveAds = Convert.ToBoolean(remove);
        PlayerPrefs.SetInt("RemoveAds", remove);
        PlayerPrefs.Save();
    }

    #endregion
}
