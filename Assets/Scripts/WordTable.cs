using System.Collections.Generic;
using UnityEngine;

public class WordTable : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Word[] _words;
    [Header("")]
    [SerializeField] private int _letterAmount = 5;
    [Header("")]
    [SerializeField] private string _currentWord = "якнбн";

    private void Awake()
    {
        for (int i = 0; i < _words.Length; i++)
            _words[i].Initialize(_cellPrefab, _letterAmount);
    }

    public void AddLetterToWord(char letter, KeyButton keyButton)
    {
        for(int i = 0; i < _words.Length; i++)
        {
            if(_words[i].IsCompletedWord == false)
            {
                _words[i].AddLetterToCell(letter, keyButton, out bool isCompletedWord);
                if (isCompletedWord)
                    CheckWord();

                return;
            }
        }
    }

    public void CheckWord()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            if (_words[i].IsCompletedWord == false)
            {
                _words[i].IsCorrectWord(_currentWord, out bool isTargetWord);

                if (isTargetWord)
                    Debug.Log("Win");

                return;
            }
        }
    }
}
