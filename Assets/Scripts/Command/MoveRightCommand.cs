using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : Command
{
    private TetrisBlock moveObject;

    public MoveRightCommand(TetrisBlock moveObject)
    {
        this.moveObject = moveObject;
    }

    public override void Execute()
    {
        moveObject.MoveRight();
    }

    public override void Undo()
    {
        moveObject.MoveLeft();
    }
}
