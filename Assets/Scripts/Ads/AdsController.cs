using UnityEngine;

public class AdsController : MonoBehaviour
{
    [SerializeField] private AdsInterstitial _adsInterstitial;

    private static AdsController _instance;
    
    public static AdsController Instance => _instance;
    public AdsInterstitial AdsInterstitial => _adsInterstitial;

    private void Awake() => SetUpSingelton();

    private void SetUpSingelton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
