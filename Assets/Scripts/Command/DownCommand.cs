using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCommand : Command
{
    private TetrisBlock moveObject;

    public DownCommand(TetrisBlock moveObject)
    {
        this.moveObject = moveObject;
    }

    public override void Execute()
    {
        moveObject.GoDown();
    }

    public override void Undo()
    {
        //moveObject.MoveBack();
    }
}
