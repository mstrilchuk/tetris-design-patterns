using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{
    public override void PrepareState()
    {
        base.PrepareState();

        owner.UI.MenuView.OnStartClicked += StartClicked;
        owner.UI.MenuView.OnQuitClicked += QuitClicked;

        owner.UI.MenuView.ShowView();
    }

    public override void DestroyState()
    {
        owner.UI.MenuView.HideView();

        owner.UI.MenuView.OnStartClicked -= StartClicked;
        owner.UI.MenuView.OnQuitClicked -= QuitClicked;

        base.DestroyState();
    }

    private void StartClicked()
    {
        owner.ChangeState(new GameState());
    }

    private void QuitClicked()
    {
        Application.Quit();
    }
}
