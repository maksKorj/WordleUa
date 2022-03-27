using UnityEngine;

public class KeyButton : CommonCell
{
    [SerializeField] private char _letter;

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
