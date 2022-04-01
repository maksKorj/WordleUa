using System.Collections;
using UnityEngine;

public class WordTable : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Word[] _words;
    [Header("")]
    [SerializeField] private EndGamePopupStats _endGamePopupStats;
    [SerializeField] private HiddenWord _hiddenWord;
    [SerializeField] private HintEffect _wordAbsenceEffect;
    [SerializeField] private HintEffect _removeLetterHint;
    [Header("")]
    [SerializeField] private int _letterAmount = 5;
    
    private string _currentWord = "";
    private bool _canTyping = true;
    private WaitForSeconds _delay;

    private void Awake()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            _words[i].Initialize(_cellPrefab, _letterAmount);
            _words[i].OnManyTaps += () => _removeLetterHint.Play();
        }
            
        _currentWord = WordGiver.Instance.GetWord();
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

    private int _tapCount;
    private void CheckWord()
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
                else
                {
                    _wordAbsenceEffect.Play();
                    return;
                }

                if (isTargetWord)
                {
                    StartCoroutine(WaitAndShowWinPopUp(i + 1));
                    return;
                }

                if(i == _words.Length - 1)
                {
                    StartCoroutine(WaitAndShowLosePopup());
                    return;
                }

                return;
            }
        }
    }

    private IEnumerator WaitAndAllowToType()
    {
        if (_delay == null)
            _delay = new WaitForSeconds(CellAnimation);

        yield return _delay;

        _canTyping = true;
    }

    private IEnumerator WaitAndShowWinPopUp(int winAttempt)
    {
        _canTyping = false;
        yield return new WaitForSeconds(CellAnimation + 0.7f);
        _endGamePopupStats.Open(winAttempt);
    }

    private IEnumerator WaitAndShowLosePopup()
    {
        _canTyping = false;
        yield return new WaitForSeconds(CellAnimation);
        _hiddenWord.Show(_currentWord);
        yield return new WaitForSeconds(_hiddenWord.AnimationTime + 1.25f);
        _endGamePopupStats.Open(0);
    }

    private float CellAnimation => _letterAmount * 0.2f + _cellPrefab.FlipTime;
}
