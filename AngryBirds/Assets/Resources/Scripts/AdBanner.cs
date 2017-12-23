using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdBanner : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        string appId = "ca-app-pub-3940256099942544~3347511713";
        MobileAds.Initialize(appId);
        RequestBanner();
    }	

    public void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        //***For Testing in the Device***
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("6BC81F06817BFD3CBEA5D1F75C6621E7")    // My test device.
       .Build();

        //***For Production When Submit App***
        //AdRequest request = new AdRequest.Builder().Build();


        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        bannerView.LoadAd(request);

        bannerView.Show();

    }
}
