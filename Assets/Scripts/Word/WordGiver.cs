using System.Collections.Generic;
using UnityEngine;

public class WordGiver : MonoBehaviour
{
    [SerializeField] private TextAsset _hiddenWordsTxt;
    [SerializeField] private TextAsset _checkingWordsTxt;

    private string[] _hiddenWords;
    private HashSet<string> _checkingWords;

    private static WordGiver _instance;
    public static WordGiver Instance => _instance;


    private void Awake()
    {
        SetUpSingleton();
        
        _hiddenWords = _hiddenWordsTxt.text.Split(' ');
        _checkingWords = new HashSet<string>(_checkingWordsTxt.text.Split(' '));
    }

    private void SetUpSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public string GetWord()
    {
        string word = "";
        
        while (word.Length != 5)
        {
            word = _hiddenWords[Random.Range(0, _hiddenWords.Length)];
        }

        return word;
    }

    public bool IsContainedWord(string word) => _checkingWords.Contains(word);
}
