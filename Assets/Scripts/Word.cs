using UnityEngine;

public class Word : MonoBehaviour
{
    private Cell[] _cell;

    public bool IsCompletedWord { get; private set; }

    public void Initialize(Cell cell, int letterAmount)
    {
        _cell = new Cell[letterAmount];

        for(int i = 0; i < letterAmount; i++)
        {
            _cell[i] = Instantiate(cell);
            _cell[i].gameObject.transform.SetParent(transform);
        }   
    }

    public void AddLetterToCell(char letter, KeyButton keyButton)
    {
        for(int i = 0; i < _cell.Length; i++)
        {
            if(_cell[i].Letter == null)
            {
                _cell[i].SetLetter(letter, keyButton);

                return;
            }    
        }
    }

    public void RemoveLetter()
    {
        for (int i = _cell.Length - 1; i >= 0; i--)
        {
            if (_cell[i].Letter != null)
            {
                _cell[i].Clear();
                return;
            }   
        }
    }

    public bool IsCorrectWord(string word, out bool isTargetWord)
    {
        if(IsAllLetterContained() == false)
        {
            Debug.Log("There are empty cells!!!");
            isTargetWord = false;
            
            return false;
        }
        //TodoCheckOnContainedInListOfWords;

        isTargetWord = IsTargetWord(word);

        for (int i = 0; i < _cell.Length; i++)
            CheckCell(_cell[i], i, word);

        IsCompletedWord = true;
        return true;
    }

    private bool IsAllLetterContained()
    {
        for (int i = 0; i < _cell.Length; i++)
        {
            if (_cell[i].Letter == null)
                return false;
        }

        return true;
    }

    private bool IsTargetWord(string word)
    {
        for (int i = 0; i < _cell.Length; i++)
        {
            if (_cell[i].Letter != word[i])
                return false;
        }

        return true;
    }

    private void CheckCell(Cell cell, int index, string word)
    {
        if(cell.Letter == word[index])
        {
            cell.SetColor(ColorState.CORRECT);
            return;
        }

        for(int i = 0; i < word.Length; i++)
        {
            if(cell.Letter == word[i])
            {
                cell.SetColor(ColorState.CONTAINED);
                return;
            }   
        }

        cell.SetColor(ColorState.NOT_CONTAINED);
    }
}
