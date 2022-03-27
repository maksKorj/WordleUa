
public class Cell : CommonCell
{
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

    public void SetLetter(char letter, KeyButton keyButton)
    {
        _text.text = letter.ToString().ToUpper();
        KeyButton = keyButton;
    }

    public void Clear() => _text.text = null;

    public override void SetColor(ColorState colorState)
    {
        KeyButton.SetColor(colorState);
        base.SetColor(colorState);
    }
}
