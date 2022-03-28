using System.Collections;
using UnityEngine;

public class Word : MonoBehaviour
{
    private Cell[] _cell;
    private WaitForSeconds _delay = new WaitForSeconds(0.2f);

    public bool IsCompletedWord { get; private set; }

    public void Initialize(Cell cell, int letterAmount)
    {
        _cell = new Cell[letterAmount];

        for(int i = 0; i < letterAmount; i++)
        {
            _cell[i] = Instantiate(cell);
            _cell[i].gameObject.transform.SetParent(transform);
            _cell[i].gameObject.transform.localScale = Vector3.one;
        }   
    }

    public void AddLetterToCell(char letter, KeyButton keyButton, out bool isCompletedWord)
    {
        isCompletedWord = false;

        for(int i = 0; i < _cell.Length; i++)
        {
            if(_cell[i].Letter == null)
            {
                _cell[i].SetLetter(letter, keyButton);
                isCompletedWord = (i == _cell.Length - 1);
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
        //TodoCheckOnContainedInListOfWords;

        isTargetWord = IsTargetWord(word);

        StartCoroutine(FlipCells(word));

        IsCompletedWord = true;
        return true;
    }

    private IEnumerator FlipCells(string word)
    {
        for (int i = 0; i < _cell.Length; i++)
        {
            CheckCell(_cell[i], i, word);
            yield return _delay;
        }
           
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
