using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving_Grounded_Walking : State<PlayerMovements>
{
    public PlayerMovements_Moving_Grounded_Walking(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {
        
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        origin.rb.velocityX = Input.GetAxisRaw("Horizontal") * origin.walkSpeed;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            parentLayer.ChangeState("Idle");
        }
        else if (Input.GetKey(origin.runKey))
        {
            parentLayer.ChangeState("Running");
        }
    }
}
