using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements_TopLayer : TopLayer<PlayerMovements>
{
    public PlayerMovements_TopLayer(PlayerMovements origin) : base(origin)
    {
        defaultState = new PlayerMovements_Moving(origin, this);
        AddState("Moving", defaultState);
        AddState("Disabled", new PlayerMovements_Disabled(origin, this));
    }
}
