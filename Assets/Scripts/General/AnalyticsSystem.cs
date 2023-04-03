using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Analytics;


public class AnalyticsSystem : MonoBehaviour
{
    #region Singleton Initialize

    private static AnalyticsSystem _current;
    public static AnalyticsSystem Current
    {
        get { return _current ?? (_current = (AnalyticsSystem)FindObjectOfType(typeof(AnalyticsSystem))); }
    }

    #endregion

    private bool _isInitialized = false;

    // Analytics Sample
    void Start()
    {
        Init();
    }

    async void Init()
    {
        if (!(Application.internetReachability == NetworkReachability.NotReachable))
        {
            await UnityServices.InitializeAsync();
            await AnalyticsService.Instance.CheckForRequiredConsents();
            _isInitialized = true;
            LogManager.analyticsLogger.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        }
    }

    public void RecordHighScore(int highScore)
    {
        if (_isInitialized) 
        {
            var parameters = new Dictionary<string, object>
            {
                { "HighScore", highScore },
            };

            AnalyticsService.Instance.CustomData("HighScore", parameters);
            LogManager.analyticsLogger.Log("HighScore Recorded.");
        }
        else
        { Init(); }
        
    }

}

