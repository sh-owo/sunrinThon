using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_Moving_Midair : State<PlayerMovements>
{
    public PlayerMovements_Moving_Midair(PlayerMovements origin, Layer<PlayerMovements> parent) : base(origin, parent)  
    {

    }
    public override void OnStateUpdate()
    {
        if (origin.GroundCheck())
        {
            parentLayer.ChangeState("Grounded");
            return;
        }
        base.OnStateUpdate();
        float axis = Input.GetAxisRaw("Horizontal");
        if (axis == 1)
        {
            if (origin.rb.velocityX >= origin.midairSpeedLimit) return;
            origin.rb.velocityX += origin.midairSpeed * Time.deltaTime;
        }
        else if (axis == -1)
        {
            if (origin.rb.velocityX <= -origin.midairSpeedLimit) return;
            origin.rb.velocityX -= origin.midairSpeed * Time.deltaTime;
        }
    }
}
