using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : Command
{
    private TetrisBlock moveObject;

    public MoveLeftCommand(TetrisBlock moveObject)
    {
        this.moveObject = moveObject;
    }

    public override void Execute()
    {
        moveObject.MoveLeft();
    }

    public override void Undo()
    {
        moveObject.MoveRight();
    }
}
