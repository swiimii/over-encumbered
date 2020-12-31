using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float direction;
    protected override void Update()
    {
        base.Update();
        if(wallRight || wallLeft || IsWalkingOffEdge())
        {
            direction *= -1;
        }
        if(isGrounded)
        {
            Move(direction);
        }
    }
    public bool IsWalkingOffEdge()
    {
        var col = GetComponent<Collider2D>();
        var origin = new Vector2(col.bounds.center.x + col.bounds.extents.x * direction, col.bounds.min.y);
        var rayDirection = Vector2.down;
        var distance = .2f;

        var rayHit = Physics2D.Raycast(origin, rayDirection, distance, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Platform"));
        Debug.DrawRay(origin, rayDirection*distance, Color.red);

        return rayHit.transform ? false : true;
    }
}
