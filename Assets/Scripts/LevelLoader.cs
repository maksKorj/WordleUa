using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Image _background;

    private readonly string _startMenu = "StartMenu", _level = "MainGame";
    private string _loadingScene;

    private void Awake()
        => _background.DOFade(0, 1f).OnComplete(() => _background.gameObject.SetActive(false));

    public void LoadStartMenu()
    {
        _loadingScene = _startMenu;
        AdsController.Instance.AdsInterstitial.ShowAd(PlayAnimationAndLoad);
    }
    public void LoadLevel()
    {
        _loadingScene = _level;
        AdsController.Instance.AdsInterstitial.ShowAd(PlayAnimationAndLoad);
    }

    private void PlayAnimationAndLoad()
    {
        _background.gameObject.SetActive(true);
        _background.DOFade(1, 1f).OnComplete(() => SceneManager.LoadScene(_loadingScene));
    }
}
