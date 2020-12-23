using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 8;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        var movement = LocalPlayerInput.GetHorizontalMovement() * movementSpeed;
        var spr = GetComponent<SpriteRenderer>();

        if (movement < 0 && !wallLeft || movement > 0 && !wallRight)
        {
            transform.position += Time.deltaTime * movement * Vector3.right;
            spr.flipX = movement < 0;
        }

        if(LocalPlayerInput.IsPressingJump() && isReadyToJump)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Collectible>().Pickup();
        }
    }

}
