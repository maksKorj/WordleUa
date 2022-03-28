using TMPro;
using UnityEngine;

public class KeyButton : ColorChanger
{
    [SerializeField] private char _letter;
    [SerializeField] private TextMeshProUGUI _text;

    private WordTable _wordTable;

    private void Awake()
        => _text.text = _letter.ToString().ToUpper();

    public void Click()
    {
        if (_wordTable == null)
            _wordTable = FindObjectOfType<WordTable>();

        _wordTable.AddLetterToWord(_letter, this);
    }

    public override void SetColor(ColorState colorState)
    {
        if (_background.color == _colorCorrectPlace)
            return;

        base.SetColor(colorState);
    }
}
