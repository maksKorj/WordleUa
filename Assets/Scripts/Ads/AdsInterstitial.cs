using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsInterstitial : MonoBehaviour
{
    [SerializeField] private string _interstitialUnitId = "ca-app-pub-3940256099942544/1033173712";
    [SerializeField] private int _gameAmountBeforeShowAds = 2;

    private InterstitialAd _interstitialAd;
    private int _count = 0;
    private Action _onAdsClosed;

    void Start()
    {
        _interstitialAd = new InterstitialAd(_interstitialUnitId);
        _interstitialAd.LoadAd(GetRequest());

        _interstitialAd.OnAdClosed += HandleOnAdClosed;
    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        _onAdsClosed?.Invoke();
        _interstitialAd.LoadAd(GetRequest());
    }

    private AdRequest GetRequest() => new AdRequest.Builder().Build();

    public void ShowAd(Action onAdsClosed)
    {
        _onAdsClosed = onAdsClosed;
        _count++;

        if(_count > _gameAmountBeforeShowAds)
        {
            _count = 0;

            if (_interstitialAd.IsLoaded())
                _interstitialAd.Show();
            else
                _onAdsClosed?.Invoke();

            return;
        }

        _onAdsClosed?.Invoke();
    }
}
