using UnityEngine;
using GoogleMobileAds.Api;

public class AdsInitialize : MonoBehaviour
{
    private void Start() => MobileAds.Initialize(initStatus => { });
}
