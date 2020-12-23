using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : Character
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        var movement = LocalPlayerInput.GetHorizontalMovement() * movementSpeed;
        bool isMoving = false, isJumping = false;
        if (movement < 0 && !wallLeft || movement > 0 && !wallRight)
        {
            Move(movement);
            isMoving = true;
        }

        if(LocalPlayerInput.IsPressingJump() && isReadyToJump)
        {
            Jump();
            isJumping = false;
        }
        
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Collectible>().Pickup();
        }
    }

}
