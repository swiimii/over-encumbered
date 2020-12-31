using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : Character
{
    // Start is called before the first frame update
    private Animator animator;
    private bool isInvincible = false;
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
        bool isMoving = false;
        //if (movement < 0 && !wallLeft || movement > 0 && !wallRight)
        if(!isInvincible)
        {
            if (!isInvincible &&!(movement < 0 && wallLeft || movement > 0 && wallRight))
            {
                Move(movement);
                isMoving = movement != 0;
            }

            if(LocalPlayerInput.IsPressingJump() && isReadyToJump)
            {
                Jump();
            }
        }
        
        animator.SetBool("isMoving", isMoving);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Collectible>().Pickup();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(other.transform.position);
        }
    }

    public void Damage(Vector2 sourceLocation)
    {
        var duration = 1f;
        if (!isInvincible)
        {
            StartCoroutine(DamageThenInvincible(duration, sourceLocation));
        }
    }

    public IEnumerator DamageThenInvincible(float duration, Vector2 sourceLocation)
    {
        isInvincible = true;
        var sr = GetComponent<SpriteRenderer>();
        var regularColor = sr.color;
        var transparentColor = new Color(regularColor.r, regularColor.g, regularColor.b, regularColor.a/2);
        IEnumerator Blink()
        {
            var blinkDelay = 0.2f;
            while(true)
            {
                sr.color = transparentColor;
                yield return new WaitForSeconds(blinkDelay);
                sr.color = regularColor;
                yield return new WaitForSeconds(blinkDelay);
            }
        }
        // Knock Back

        
        // ignore collision until not invincible
        int enemyLayer = 0, playerLayer = 11;
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, true);

        // blink character for duration
        var routine = Blink();
        StartCoroutine(routine);
        yield return new WaitForSeconds(duration);
        
        // teardown
        StopCoroutine(routine);
        sr.color = regularColor;
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        isInvincible = false;
        
    }
}
