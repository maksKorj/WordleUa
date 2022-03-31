using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Image _background;

    private readonly string _startMenu = "StartMenu", _level = "MainGame";

    private void Awake()
        => _background.DOFade(0, 1f).OnComplete(() => _background.gameObject.SetActive(false));

    public void LoadStartMenu() => PlayAnimationAndLoad(_startMenu);
    public void LoadLevel() => PlayAnimationAndLoad(_level);

    private void PlayAnimationAndLoad(string sceneName)
    {
        _background.gameObject.SetActive(true);
        _background.DOFade(1, 1f).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
