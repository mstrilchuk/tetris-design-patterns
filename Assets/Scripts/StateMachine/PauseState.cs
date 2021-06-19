using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public override void PrepareState()
    {
        base.PrepareState();

        Time.timeScale = 0;

        owner.UI.PauseView.OnMenuClicked += MenuClicked;
        owner.UI.PauseView.OnResumeClicked += ResumeClicked;

        owner.UI.PauseView.ShowView();
    }

    public override void DestroyState()
    {
        owner.UI.PauseView.HideView();

        owner.UI.PauseView.OnMenuClicked -= MenuClicked;
        owner.UI.PauseView.OnResumeClicked -= ResumeClicked;

        Time.timeScale = 1;

        base.DestroyState();
    }

    private void MenuClicked()
    {
        owner.ChangeState(new GameState { skipToFinish = true });
    }

    private void ResumeClicked()
    {
        owner.ChangeState(new GameState { loadGameContent = false });
    }

}
