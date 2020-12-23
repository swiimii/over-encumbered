﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Character : MonoBehaviour
{
    public float jumpVelocity = .3f, movementSpeed = 5;

    protected int maxHealth, currentHealth;
    protected bool isGrounded=false, isReadyToJump=true, isPreparingToJump=false, wallRight=false, wallLeft=false;
    protected float jumpDelay = .1f;

    protected virtual void Update()
    {
        isGrounded = CheckIfGrounded();
        wallRight = CheckWall(1);
        wallLeft = CheckWall(-1);
        if(isGrounded)
        {
            if(!isReadyToJump && !isPreparingToJump)
            {
                StartCoroutine(JumpCooldown());
                isPreparingToJump = true;
            }
        }
        else
        {
            StopCoroutine(JumpCooldown());
            isPreparingToJump = false;
            isReadyToJump = false;
        }
    }

    protected virtual void Jump()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    protected virtual bool CheckIfGrounded()
    {
        var col = GetComponent<Collider2D>();
        var startPoint = new Vector2(col.bounds.center.x, col.bounds.min.y);
        var direction = Vector2.down;
        var distance = .1f;
        var hit = Physics2D.Raycast(startPoint, direction, distance, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Platform"));
        Debug.DrawRay(startPoint, direction * distance, Color.green);

        if (hit.transform)
        {
            return true;
        }
        return false;
    }

    protected virtual bool CheckWall(int direction)
    {
        // `direction` should be either +1 or -1
        var col = GetComponent<Collider2D>();
        var numOfRays = 6;
        var distance = .1f;
        var deadZone = .1f;
        var startingHeight = col.bounds.min.y + deadZone;
        var endingHeight = col.bounds.max.y - deadZone;
        var interval = (endingHeight - startingHeight) / (numOfRays-1);
        var extents = col.bounds.extents.x;

        for (int i = 0; i < numOfRays; i++)
        {
            var rayHeight = startingHeight + interval * i;
            var startingPoint = new Vector2(transform.position.x + direction * extents, rayHeight);
            var hit = Physics2D.Raycast(startingPoint, transform.right * direction, distance, 1 << LayerMask.NameToLayer("Ground"));
            Debug.DrawRay(startingPoint, Vector2.right * direction * distance, Color.blue);
            if(hit.transform)
            {
                return true;
            }
        }

        return false;
    }

    protected virtual void Move(float movement)
    {
        var spr = GetComponent<SpriteRenderer>();
        transform.position += Time.deltaTime * movementSpeed * movement * Vector3.right;
        spr.flipX = movement < 0;
    }

    protected virtual IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpDelay);
        isReadyToJump = true;
    }
}
