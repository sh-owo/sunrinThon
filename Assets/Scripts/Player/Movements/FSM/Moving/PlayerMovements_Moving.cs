using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving : Layer<PlayerMovements>
{
    public PlayerMovements_Moving(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {
        AddState("Grounded", new PlayerMovements_Moving_Grounded(origin, this));
        AddState("Midair", new PlayerMovements_Moving_Midair(origin, this));
    }
    public override void OnStateEnter()
    {
        if (origin.GroundCheck())
        {
            currentState = states["Grounded"];
        }
        else
        {
            currentState = states["Midair"];
        }
        currentState.OnStateEnter();
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        if (origin.canMove == false)
        {
            Debug.Log(parentLayer == null);
            parentLayer.ChangeState("Disabled");
        }
    }
}
