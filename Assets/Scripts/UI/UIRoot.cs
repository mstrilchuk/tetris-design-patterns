using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private MenuView menuView;
    public MenuView MenuView => menuView;

    [SerializeField]
    private GameView gameView;
    public GameView GameView => gameView;

    [SerializeField]
    private PauseView pauseView;
    public PauseView PauseView => pauseView;

    [SerializeField]
    private GameOverView gameOverView;
    public GameOverView GameOverView => gameOverView;
}
