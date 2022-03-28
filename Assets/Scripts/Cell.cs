using UnityEngine;
using DG.Tweening;

public class Cell : CommonCell
{
    [SerializeField] private CommonCell _border;
    
    public KeyButton KeyButton { get; private set; }
    
    public char? Letter
    {
        get
        {
            if (_text.text == null || _text.text == "")
                return null;

            return _text.text[0];
        }
    }

    public bool IsPainted { get; private set; }

    public void SetLetter(char letter, KeyButton keyButton)
    {
        _text.text = letter.ToString().ToUpper();
        KeyButton = keyButton;
    }

    public void Clear() => _text.text = null;

    public override void SetColor(ColorState colorState)
    {
        IsPainted = true;
        
        KeyButton.SetColor(colorState);
        _border.SetColor(colorState);
        
        base.SetColor(colorState);
    }
}
