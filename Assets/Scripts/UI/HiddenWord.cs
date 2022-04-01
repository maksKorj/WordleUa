using UnityEngine;
using TMPro;
using DG.Tweening;

public class HiddenWord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public float AnimationTime { get; private set; } = 0.5f;

    public void Show(string word)
    {
        gameObject.SetActive(true);
        _text.text = word;

        GetComponent<RectTransform>().DOScale(Vector3.one, AnimationTime);
    }
}
