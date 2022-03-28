using System.Collections;
using UnityEngine;

public class WordTable : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Word[] _words;
    [Header("")]
    [SerializeField] private int _letterAmount = 5;
    [Header("")]
    [SerializeField] private string _currentWord = "якнбн";

    private bool _canTyping = true;
    private WaitForSeconds _delay;

    private void Awake()
    {
        for (int i = 0; i < _words.Length; i++)
            _words[i].Initialize(_cellPrefab, _letterAmount);
    }

    public void AddLetterToWord(char letter, KeyButton keyButton)
    {
        if (_canTyping == false)
            return;

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
                if(_words[i].IsCorrectWord(_currentWord, out bool isTargetWord))
                {
                    _canTyping = false;
                    StartCoroutine(WaitAndAllowToType());
                }

                if (isTargetWord)
                    Debug.Log("Win");

                return;
            }
        }
    }

    private IEnumerator WaitAndAllowToType()
    {
        if (_delay == null)
            _delay = new WaitForSeconds(_letterAmount * 0.2f + _cellPrefab.FlipTime);

        yield return _delay;

        _canTyping = true;
    }
}
