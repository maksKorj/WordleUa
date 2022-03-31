using UnityEngine;

public class FirstStartHandler : MonoBehaviour
{
    [SerializeField] private PopupAnimation _guidePopup;

    private string _firstStartPath = "FirstStart";

    private void Awake()
    {
        if(PlayerPrefs.HasKey(_firstStartPath) == false)
        {
            PlayerPrefs.SetInt(_firstStartPath, 0);
            _guidePopup.OpenWithoutAnimation();
        }
    }
}
