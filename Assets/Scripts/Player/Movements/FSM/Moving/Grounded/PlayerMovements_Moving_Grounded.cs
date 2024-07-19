using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving_Grounded : Layer<PlayerMovements>
{
    public PlayerMovements_Moving_Grounded(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {
        defaultState = new PlayerMovements_Moving_Grounded_Idle(origin, this);
        AddState("Idle", defaultState);
        AddState("Walking", new PlayerMovements_Moving_Grounded_Walking(origin, this));
        AddState("Running", new PlayerMovements_Moving_Grounded_Running(origin, this));
    }
    public override void OnStateUpdate()
    {
        if (origin.GroundCheck() == false)
        {
            parentLayer.ChangeState("Midair");
            return;
        }
        base.OnStateUpdate();
        if (Input.GetKeyDown(origin.jumpKey))
        {
            origin.rb.velocityY = origin.jumpPower;
        }
    }
}
