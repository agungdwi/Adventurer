using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   public Animator animator;
   public Transform AttackPoint;
   public Transform bandit;
   public LayerMask EnemyLayers;
   public Rigidbody2D rb;

   public static float AttackRange = 0.28f;
   public static int AttackDamage = 20;
   public static float AttackRate = 0.5f;
   float NextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= NextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // animasi attack
                AudioManagerScript.PlaySound("Attack");
                animator.SetTrigger("Attack");
                NextAttackTime = Time.time +1f/AttackRate;
            }
        }

        var bandit1 = bandit.GetComponent<EnemyHealth>();
        bandit1.knockbackCount = bandit1.knockbackLength;

        if (bandit.transform.position.x < transform.position.x){
               bandit1.knockbackFromRight = true;
        }
        else{
               bandit1.knockbackFromRight = false;
        }
        
    }
    

    void Attack ()
    {

        // menemukan musuh dalam jarak serang
        Collider2D [] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        // Kasih Damage
        foreach (Collider2D enemy in HitEnemies)
        {

          var bandit1 = enemy.GetComponent<EnemyHealth>();
          bandit1.TakeDamage(AttackDamage);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    public void AttackDamageUp (){
        AttackDamage += 10;
    }

    public void AttackRateUp (){
        AttackRate += 1;
    }
}
