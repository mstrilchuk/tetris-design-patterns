using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private TetrisBlock objectThatMoves;

    private Command buttonW;
    private Command buttonA;
    private Command buttonS;
    private Command buttonD;

    private Stack<Command> undoCommands = new Stack<Command>();
    private Stack<Command> redoCommands = new Stack<Command>();

    private bool isReplaying = false;

    private Vector3 startPos;

    private const float REPLAY_PAUSE_TIMER = 0.5f;


    void Start()
    {
        UpdComponent();
    }
    
    void Update()
    {
        if (isReplaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ExecuteNewCommand(buttonW);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ExecuteNewCommand(buttonA);
        }
        /*else if (Input.GetKey(KeyCode.S))
        {
            ExecuteNewCommand(buttonS);
        } */
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ExecuteNewCommand(buttonD);
        }
        else if (Input.GetKeyDown(KeyCode.U)) //Undo with u (ctrl + z is sometimes interfering with the editor's undo system)
        {
            if (undoCommands.Count == 0)
            {
                Debug.Log("Can't undo because we are back where we started");
            }
            else
            {
                Command lastCommand = undoCommands.Pop();
                lastCommand.Undo();
                redoCommands.Push(lastCommand);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (redoCommands.Count == 0)
            {
                Debug.Log("Can't redo because we are at the end");
            }
            else
            {
                Command nextCommand = redoCommands.Pop();
                nextCommand.Execute();
                undoCommands.Push(nextCommand);
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapKeys(ref buttonA, ref buttonD);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Replay());

            isReplaying = true;
        }
    }

    private IEnumerator Replay()
    {
        objectThatMoves.transform.position = startPos;
        yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);
        Command[] oldCommands = undoCommands.ToArray();

        for (int i = oldCommands.Length - 1; i >= 0; i--)
        {
            Command currentCommand = oldCommands[i];

            currentCommand.Execute();

            yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);
        }

        isReplaying = false;
    }

    private void ExecuteNewCommand(Command commandButton)
    {
        commandButton.Execute();
        undoCommands.Push(commandButton);
        redoCommands.Clear();
    }

    private void SwapKeys(ref Command key1, ref Command key2)
    {
        Command temp = key1;
        key1 = key2;
        key2 = temp;
    }

    public void UpdComponent()
    {
        objectThatMoves = GameObject.FindGameObjectWithTag("newtetromino").GetComponent<TetrisBlock>();

        buttonW = new RotateCommand(objectThatMoves);
        buttonA = new MoveLeftCommand(objectThatMoves);
        //buttonS = new DownCommand(objectThatMoves);
        buttonD = new MoveRightCommand(objectThatMoves);

        startPos = objectThatMoves.transform.position;
    }
}

