using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float direction;
    protected override void Update()
    {
        base.Update();
        if(wallRight)
        {
            direction = -1;
        }
        else if(wallLeft)
        {
            direction = 1;
        }
        
        if(isGrounded)
        {
            Move(direction);
        }
    }
}
