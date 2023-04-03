using UnityEngine;
using DG.Tweening;
using System;

public class UIEventManager : MonoBehaviour
{

    #region Singleton Initialize

    private static UIEventManager _current;
    public static UIEventManager Current
    {
        get { return _current ?? (_current = (UIEventManager) FindObjectOfType(typeof (UIEventManager))); }
    }

    #endregion


    public GameObject OpenningPanel;
    public GameObject EndGamePanel;

    public GameObject GamePanel;

    public DistanceMeter DistanceMeter;

    public DOTweenAnimation Score;
    public DOTweenAnimation HighScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackButtonPushed();
        }
    }

    public void BackButtonPushed()
    { 
        Application.Quit();
    }

    public void LoadVampire()
    {
        OpenningPanel.SetActive(true);
    }

    public void LoadGame()
    {
        GamePanel.SetActive(true);
        Bat.Current.InitializeFirstPass();
    }

    public void LoadEndGame()
    {
        if (Game.Current.Distance > GameData.Current.HighScore)
        {
            GameData.Current.SetHighScore(Game.Current.Distance);
        }

        EndGamePanel.SetActive(true);

        ((Tweener)Score.tween).ChangeEndValue(Game.Current.Distance.ToString());
        ((Tweener)HighScore.tween).ChangeEndValue(GameData.Current.HighScore.ToString());
    }

    public void UnLoadVampire()
    {
        OpenningPanel.SetActive(false);
    }

    public void UnLoadEndGame()
    {
        Score.DOPlayBackwards();
        HighScore.DOPlayBackwards();
        ParallaxManager.Instance.Reset();
    }

    public void UnLoadGame()
    {
        GamePanel.SetActive(false);
    }

    public void Play()
    {
        Game.Current.Initialize();
        DistanceMeter.enabled = true;
    }
}
