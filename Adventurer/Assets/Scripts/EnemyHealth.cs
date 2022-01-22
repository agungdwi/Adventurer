using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2;

    public int MaxHealth = 100;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockbackFromRight;

    int CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth  = MaxHealth;
    }

    public void TakeDamage (int Damage)
    {

        CurrentHealth -= Damage;
        AudioManagerScript.PlaySound("BanditHit");
        animator.SetTrigger("Hurt");

        GetComponent<FollowAi>().Stop();
        knockbackPLayer ();

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void knockbackPLayer (){
        if (knockbackFromRight)
           rb.velocity = new Vector2 (-knockback, 2);

        if (!knockbackFromRight)
           rb.velocity = new Vector2 (knockback, 2);

        knockbackCount -= Time.deltaTime;
    }

    public void Die ()
    {
        Killed.scoreValue += 1;
        Money.MoneyValue += 1;
        moneydd.pointvalue += 1;
        boxCol.enabled = false;
        boxCol2.enabled = false;
        AudioManagerScript.PlaySound("BanditDeath");
        animator.SetBool("Die",true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<FollowAi>().enabled = false;
        this.enabled  = false;
        Destroy(gameObject, 10);
    }
}
