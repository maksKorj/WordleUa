using System.Collections;
using UnityEngine;

public class Word : MonoBehaviour
{
    private Cell[] _cells;
    private WaitForSeconds _delay = new WaitForSeconds(0.2f);

    public bool IsCompletedWord { get; private set; }

    public void Initialize(Cell cell, int letterAmount)
    {
        _cells = new Cell[letterAmount];

        for(int i = 0; i < letterAmount; i++)
        {
            _cells[i] = Instantiate(cell);
            _cells[i].gameObject.transform.SetParent(transform);
            _cells[i].gameObject.transform.localScale = Vector3.one;
        }   
    }

    public void AddLetterToCell(char letter, KeyButton keyButton, out bool isCompletedWord)
    {
        isCompletedWord = false;

        for(int i = 0; i < _cells.Length; i++)
        {
            if(_cells[i].Letter == null)
            {
                _cells[i].SetLetter(letter, keyButton);
                isCompletedWord = IsAllLetterContained();
                return;
            }    
        }
    }

    public void RemoveLetter()
    {
        for (int i = _cells.Length - 1; i >= 0; i--)
        {
            if (_cells[i].Letter != null)
            {
                _cells[i].Clear();
                return;
            }   
        }
    }

    public bool IsCorrectWord(string word, out bool isTargetWord)
    {
        if(WordGiver.Instance.IsContainedWord(GetWrittenWord()) == false)
        {
            isTargetWord = false;
            for (int i = 0; i < _cells.Length; i++)
                _cells[i].Shake();

            return false;
        }

        isTargetWord = IsTargetWord(word);

        StartCoroutine(FlipCells(word));

        IsCompletedWord = true;
        return true;
    }

    private string GetWrittenWord()
    {
        var word = "";

        for (int i = 0; i < _cells.Length; i++)
            word += _cells[i].Letter;

        return word;
    }

    private IEnumerator FlipCells(string word)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            CheckCell(_cells[i], i, word);
            yield return _delay;
        }
           
    }

    private bool IsAllLetterContained()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].Letter == null)
                return false;
        }

        return true;
    }

    private bool IsTargetWord(string word)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].Letter != word[i])
                return false;
        }

        return true;
    }

    private void CheckCell(Cell cell, int index, string word)
    {
        if(cell.Letter == word[index])
        {
            cell.Flip(ColorState.CORRECT);
            return;
        }

        for(int i = 0; i < word.Length; i++)
        {
            if(cell.Letter == word[i])
            {
                cell.Flip(ColorState.CONTAINED);
                return;
            }   
        }

        cell.Flip(ColorState.NOT_CONTAINED);
    }
}
