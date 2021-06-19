using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : State
{
    public int gameResult;
    private Text scoreText;

    public override void PrepareState()
    {
        base.PrepareState();

        owner.UI.GameOverView.OnReplayClicked += ReplayClicked;
        owner.UI.GameOverView.OnMenuClicked += MenuClicked;

        gameResult = ScoreText.Instance._score;

        owner.UI.GameOverView.ShowView();

        scoreText = GameObject.FindGameObjectWithTag("scoretxt").GetComponent<Text>();
        scoreText.text = gameResult.ToString();
    }

    public override void DestroyState()
    {
        owner.UI.GameOverView.HideView();

        owner.UI.GameOverView.OnReplayClicked -= ReplayClicked;
        owner.UI.GameOverView.OnMenuClicked -= MenuClicked;

        base.DestroyState();
    }

    private void ReplayClicked()
    {
        owner.ChangeState(new GameState());
    }

    private void MenuClicked()
    {
        owner.ChangeState(new MenuState());
    }

}
