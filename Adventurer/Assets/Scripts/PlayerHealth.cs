using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	public Rigidbody2D rb;
	public GameObject GameOver;

    public static int Maxhealth = 100;
	public int currentHealth;
	public float BlockDamage = 90f / 100f;
	public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockbackFromRight;

	private bool blocking = false;

	public HealthBar healthbar;

	void Start()
	{
		
		currentHealth = Maxhealth;
		healthbar.SetMaxHealth(Maxhealth);
	}

	void FixedUpdate()
	{
		
		if (Input.GetButton ("Fire2"))
        {
            animator.SetBool("block idle", true);
			blocking = true;
        }
		
		else
		{
			animator.SetBool("block idle", false);
			blocking = false;
			 
		}
	}

	public void TakeDamage(int damage)
	{
		if (blocking == true)
		{
			float damagereduce = damage;
			damagereduce = damagereduce - (damagereduce * BlockDamage);
			damage = Mathf.CeilToInt(damagereduce);
			
			if (damage == Mathf.CeilToInt(damagereduce))
			{
				AudioManagerScript.PlaySound("Block");
				animator.SetTrigger ("block");
				currentHealth -= damage;
			}
		}


		else 
		{
		AudioManagerScript.PlaySound("BanditHit");
		animator.SetTrigger("Hurt");
		currentHealth -= damage;
		
		knockbackmove();
		}
		if (currentHealth <= 0)
		{
			Die();
		}

		healthbar.SetHealth(currentHealth);
	}

	public void knockbackmove (){
        if (knockbackFromRight)
           rb.velocity = new Vector2 (-knockback, 2);

        if (!knockbackFromRight)
           rb.velocity = new Vector2 (knockback, 2);

        knockbackCount -= Time.deltaTime;
    }

	public void HealthUp () {
		Maxhealth += 20;
	}

	public void Die()
	{
		AudioManagerScript.PlaySound("Death");
		animator.SetBool("Die",true);
		GameObject.FindGameObjectWithTag("Enemy").GetComponent<FollowAi>().Reset();
		GameObject.Find("Timer").GetComponent<Timer>().StopWatchStop();
		GameOver.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
		GetComponent<GerakanPlayer>().enabled = false;
		GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		this.enabled  = false;

	}

	

}
