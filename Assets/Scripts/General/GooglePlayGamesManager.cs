using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GooglePlayGamesManager : MonoBehaviour
{
    #region Singleton Initialize

    private static GooglePlayGamesManager _current;
    public static GooglePlayGamesManager Current
    {
        get { return _current ?? (_current = (GooglePlayGamesManager)FindObjectOfType(typeof(GooglePlayGamesManager))); }
    }

    #endregion

    private bool _isLoginSuccessfull = false;

    [SerializeField]
    GameObject ConnectionWarning;
    public void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            _isLoginSuccessfull = true;
            int score = GetScore();
            
        }
        else
        {
            _isLoginSuccessfull = false;
        }
    }

    public int GetScore()
    {
        int score = 0;

        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                PlayGamesPlatform.Instance.LoadScores(

                GPGSIds.leaderboard_flappy_bat,
                LeaderboardStart.PlayerCentered,
                1,
                LeaderboardCollection.Public,
                LeaderboardTimeSpan.AllTime,
                (LeaderboardScoreData data) =>
                {
                    //Debug.Log(data.Valid);
                    //Debug.Log(data.Id);
                    //Debug.Log(data.PlayerScore);
                    //Debug.Log(data.PlayerScore.userID);
                    //Debug.Log(data.PlayerScore.formattedValue);
                    score = int.Parse(data.PlayerScore.formattedValue);


                    if (score > GameData.Current.HighScore)
                    {
                        GameData.Current.SetHighScore(score);
                    }
                    else
                    {
                        score = GameData.Current.HighScore;
                        Social.ReportScore(score, GPGSIds.leaderboard_flappy_bat, (bool success) =>
                        {
                            Debug.Log("score sent " + score + " " +success);
                        });
                    }


                    Debug.Log(" user " + data.PlayerScore.userID + " score " + score);
                });
            }
        });



        return score;
    }

    public void SendScore(int Score)
    {
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ReportScore(Score, GPGSIds.leaderboard_flappy_bat, (bool success) =>
                    {
                        Debug.Log("score sent " + success);
                    });
                }
            });
    }

    public void LoadLeaderBoard()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ConnectionWarning.SetActive(true);
        }

        GetScore();

        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_flappy_bat);
            }
            else
                PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
        });
    }
}
