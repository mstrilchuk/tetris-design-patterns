using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverView : BaseView
{
    [SerializeField]
    private Text scoreText;

    public UnityAction OnReplayClicked;
    public UnityAction OnMenuClicked;

    public int score;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        score = 0;
        base.HideView();
    }

    public void ReplayClick()
    {
        OnReplayClicked?.Invoke();
    }

    public void MenuClick()
    {
        OnMenuClicked?.Invoke();
    }
}
