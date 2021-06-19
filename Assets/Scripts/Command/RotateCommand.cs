using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : Command
{
    private TetrisBlock moveObject;

    public RotateCommand(TetrisBlock moveObject)
    {
        this.moveObject = moveObject;
    }

    public override void Execute()
    {
        moveObject.Rotate();
    }

    public override void Undo()
    {
        moveObject.RotateBack();
    }
}
