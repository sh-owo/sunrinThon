using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Disabled : State<PlayerMovements>
{
    public PlayerMovements_Disabled(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {

    }
    public override void OnStateUpdate()
    {
        if (origin.canMove)
        {
            parentLayer.ChangeState("Moving");
            return;
        }
        base.OnStateUpdate();
    }
}
