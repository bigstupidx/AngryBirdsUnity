using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdInterstitial : MonoBehaviour {

    private InterstitialAd interstitial;
    // Use this for initialization
    void Start ()
    {
        RequestInterstitial();
    }
	

    public void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("6BC81F06817BFD3CBEA5D1F75C6621E7")  // My test device.
       .Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

    }

    public void show()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
