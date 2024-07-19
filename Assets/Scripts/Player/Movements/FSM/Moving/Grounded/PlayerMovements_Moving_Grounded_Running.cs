using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving_Grounded_Running : State<PlayerMovements>
{
    public PlayerMovements_Moving_Grounded_Running(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {
        
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        origin.rb.velocityX = Input.GetAxisRaw("Horizontal") * origin.runSpeed;
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            parentLayer.ChangeState("Idle");
        }
        else if (!Input.GetKey(origin.runKey))
        {
            parentLayer.ChangeState("Walking");
        }
    }
}
