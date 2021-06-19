using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    public bool loadGameContent = true;
    public bool destroyGameContent = true;
    public bool skipToFinish = false;

    GameObject[] tetrominos;

    public override void PrepareState()
    {
        base.PrepareState();

        if (skipToFinish)
        {
            owner.ChangeState(new GameOverState());
            return;
        }

        owner.UI.GameView.OnPauseClicked += PauseClicked;
        owner.UI.GameView.OnFinishClicked += FinishClicked;

        owner.UI.GameView.ShowView();

        if (loadGameContent)
        {
            GameObject.Find("SPAWNER").GetComponent<SpawnTetromino>().NewTetromino();
            ScoreText.Instance.ClearScore(0);
        }
    }

    public override void HandleInput()
    {
        base.HandleInput();

    }
    public override void UpdateState() 
    {
        base.UpdateState();
        tetrominos = GameObject.FindGameObjectsWithTag("newtetromino");
        for (int i = 0; i < tetrominos.Length; i++)
        {
            if (tetrominos[i].GetComponent<TetrisBlock>().gameOver == true)
            {
                owner.ChangeState(new GameOverState());
            }
        }
    }

    public override void DestroyState()
    {
        if (destroyGameContent)
        {
            GameObject[] tetrominos = GameObject.FindGameObjectsWithTag("tetrominos");
            GameObject[] newtetrominos = GameObject.FindGameObjectsWithTag("newtetromino");
            foreach (GameObject tetromino in tetrominos)
                GameObject.Destroy(tetromino);
            foreach (GameObject tetromino in newtetrominos)
                GameObject.Destroy(tetromino);
        }

        owner.UI.GameView.HideView();

        owner.UI.GameView.OnPauseClicked -= PauseClicked;
        owner.UI.GameView.OnFinishClicked -= FinishClicked;

        base.DestroyState();
    }

    private void PauseClicked()
    {
        destroyGameContent = false;

        owner.ChangeState(new PauseState());
    }

    private void FinishClicked()
    {
        owner.ChangeState(new GameOverState ());
    }

}
