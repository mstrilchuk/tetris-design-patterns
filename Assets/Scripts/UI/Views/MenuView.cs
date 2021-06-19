using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuView : BaseView
{
    public UnityAction OnStartClicked;
    public UnityAction OnQuitClicked;

    public void StartClick()
    {
        OnStartClicked?.Invoke();
    }

    public void QuitClick()
    {
        OnQuitClicked?.Invoke();
    }
}
