using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private PopupAnimation _popupAnimation;

    private bool _isOpen;

    private void Update()
    {
        CheckBackButtonPress();
    }

    private void CheckBackButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isOpen == false)
        {
            _popupAnimation.Open();
            _isOpen = true;
        }
    }

    public void ClosePopup()
    {
        _popupAnimation.Close();
        _isOpen = false;
    }

    public void Quit() => Application.Quit();
}
