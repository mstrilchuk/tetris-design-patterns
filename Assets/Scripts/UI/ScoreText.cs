using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Singleton
public class ScoreText : MonoBehaviour
{
    public int _score;
    private Text _text;
    
    public static ScoreText Instance { get; private set; }

    private void Awake()
    {
        _text = GetComponent<Text>();
        Instance = this;
    }

    public void AddScore(int value)
    {
        _score += value;
        _text.text = _score.ToString();
    }
    
    public void ClearScore(int value)
    {
        _score = value;
        _text.text = _score.ToString();
    }

}
