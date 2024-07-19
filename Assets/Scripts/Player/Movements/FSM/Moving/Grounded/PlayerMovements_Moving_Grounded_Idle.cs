using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving_Grounded_Idle : State<PlayerMovements>
{
    public PlayerMovements_Moving_Grounded_Idle(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {
        
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetKey(origin.runKey))
            {
                parentLayer.ChangeState("Running");
            }
            else
            {
                parentLayer.ChangeState("Walking");
            }
        }
    }
}
