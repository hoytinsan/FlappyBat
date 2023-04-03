using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region Properties

    private ObstacleGenerator _currentObstacleGenerator;
    public List<Obstacle> ActiveObstacles;

    public TextMeshProUGUI DistanceLabel;
    public GameObject TouchReceiver;

    private float _waitTime;
    private float _stateWaitTime;

    private WaitForSeconds waitHalfSecond = new WaitForSeconds(0.5f);
    private WaitForSeconds waitOneSecond = new WaitForSeconds(1);
    private WaitForSeconds waitTenSeconds = new WaitForSeconds(10);
    private WaitForSeconds waitFifteenSeconds = new WaitForSeconds(15);

    private int _distance;
    public int Distance
    {
        get { return _distance; }
        set
        {
            _distance = value;
            DistanceLabel.text = _distance.ToString();
        }
    }

    public bool IsGameOn;

    #endregion

    #region Singleton Initialize

    private static Game _current;
    public static Game Current
    {
        get { return _current ?? (_current = (Game)FindObjectOfType(typeof(Game))); }
    }

    #endregion

    public void Initialize()
    {
        LogManager.gameLogger.Log("game Initialize");
        IsGameOn = true;
        ParallaxManager.Instance.BaseSpeed = 10;
        Bat.Current.Initialize();
        TouchReceiver.SetActive(true);
        _currentObstacleGenerator = new Level_1_ObstacleGenerator(null);
        _stateWaitTime = 5;
        _waitTime = 4f;
        Play();
    }

    public void Play()
    {
        LogManager.gameLogger.Log("Play");
        StartCoroutine("ProduceObstacles");
        StartCoroutine("ReduceWaitTime");
        StartCoroutine("IncreaseParallaxSpeed");
        StartCoroutine("StateGenerator");
    }

    public void End()
    {
        StopAllCoroutines();
        StartCoroutine("EndGame");
        TouchReceiver.SetActive(false);
        IsGameOn = false;
    }

    public void Despawn()
    {
        foreach (var obstacle in ActiveObstacles)
        {
            obstacle.Despawn();
        }
    }

    #region Coroutines

    public IEnumerator EndGame()
    {
        ParallaxManager.Instance.BaseSpeed = -5f;
        yield return waitHalfSecond;
        ParallaxManager.Instance.BaseSpeed = 0f;
        UIEventManager.Current.LoadEndGame();

        yield return waitHalfSecond;
        Despawn();
    }

    public IEnumerator StateGenerator()
    {
        yield return new WaitForSeconds(_stateWaitTime);

        _currentObstacleGenerator = _currentObstacleGenerator.NextLevel();
        _stateWaitTime += 2;
        StartCoroutine("StateGenerator");
    }

    public IEnumerator IncreaseParallaxSpeed()
    {
        yield return waitTenSeconds;

        while (ParallaxManager.Instance.BaseSpeed <30)
        {
            ParallaxManager.Instance.BaseSpeed += 0.5f;
            yield return waitFifteenSeconds;
        }
    }

    public IEnumerator ReduceWaitTime()
    {
        while (_waitTime > 2f)
        {
            _waitTime -= 0.01f;
            yield return waitOneSecond;
        }
    }

    public IEnumerator ProduceObstacles()
    {
        LogManager.gameLogger.Log("produce obstacles");
        _currentObstacleGenerator.Generate();
        float random = Random.Range(1, _waitTime/2);
        yield return new WaitForSeconds(random);

        _currentObstacleGenerator.GenerateFromPreviousOG();
        yield return new WaitForSeconds(_waitTime - random);

        StartCoroutine("ProduceObstacles");
    }

    #endregion
}
