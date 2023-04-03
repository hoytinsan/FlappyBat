using System;
using UnityEngine;
using GoogleMobileAds.Api;
using Unity.Services.Analytics;
using Unity.Services.Core;
using System.Collections.Generic;

public class AddSystem : MonoBehaviour
{
    #region Singleton Initialize

    private static AddSystem _current;

    public static AddSystem Current
    {
        get { return _current ?? (_current = (AddSystem)FindObjectOfType(typeof(AddSystem))); }
    }

    #endregion


    private bool _isInitialized = false;
    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Start()
    {   
        Init();
    }

    void Init()
    {
        if (!(Application.internetReachability == NetworkReachability.NotReachable))
        {
            RequestConfiguration requestConfiguration =
           new RequestConfiguration.Builder()
           .SetSameAppKeyEnabled(true).build();
            MobileAds.SetRequestConfiguration(requestConfiguration);

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(HandleInitCompleteAction);
            _isInitialized = true;
        }
    }

    private void HandleInitCompleteAction(InitializationStatus obj)
    {
        this.RequestBanner();
    }


    private void RequestBanner()
    {
#if UNITY_ANDROID
        string _adUnitId = "ca-app-pub-6604972304117166/5877312902";
#else
      string _adUnitId = "unexpected_platform";
#endif


        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }


    public void RequestInterstitial()
    {
        if (_isInitialized)
        {
            #if UNITY_ANDROID
                        string _adUnitId = "ca-app-pub-6604972304117166/7102215924";
            #else
                              string _adUnitId = "unexpected_platform";
            #endif
            // Clean up the old ad before loading a new one.
            if (interstitial != null)
            {
                interstitial.Destroy();
                interstitial = null;
            }

            Debug.Log("Loading the interstitial ad.");

            // create our request used to load the ad.
            var adRequest = new AdRequest.Builder().Build();

            // send the request to load the ad.
            InterstitialAd.Load(_adUnitId, adRequest,
                (InterstitialAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
                    if (error != null || ad == null)
                    {
                        Debug.LogError("interstitial ad failed to load an ad " +
                                       "with error : " + error);
                        return;
                    }

                    Debug.Log("Interstitial ad loaded with response : "
                              + ad.GetResponseInfo());

                    interstitial = ad;
                });
        }
        else
        { Init(); }
    }

}
