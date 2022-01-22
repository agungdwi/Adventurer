using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAi : MonoBehaviour
{
    public LayerMask DamageMask;
    public Transform AttackPoint;
    public Transform Player;
    public Animator animator;
    public static int AttackDamage = 4;
    public float speed;
    public float move = 0f;
    public float LineOfsite;
    public float AttackRange;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void update ()
    {
         GetComponent<Look>().LookAtPlayer();
    }
    
    void FixedUpdate()
    {
        
        float Distance = Vector2.Distance(Player.position, transform.position);

        if (Distance < LineOfsite && Distance > AttackRange) 
        {
            GetComponent<Look>().LookAtPlayer();
            animator.SetBool("combat", false);
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed*Time.deltaTime);
            Running ();
        }
        else if (Distance > LineOfsite && Distance > AttackRange) 
        {
            Stop();
        }
        else if (Distance < AttackRange)
        {
            GetComponent<Look>().LookAtPlayer();
            animator.SetBool("combat", true);
            animator.SetTrigger("Attack");
            Stop();
        }


         var player = Player.GetComponent<PlayerHealth>();
         player.knockbackCount = player.knockbackLength;

           if (Player.transform.position.x < transform.position.x){
               player.knockbackFromRight = true;
           }
           else{
               player.knockbackFromRight = false;
           }
        
    }

    void Attack ()
    {

        // menemukan musuh dalam jarak serang
        Collider2D [] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, DamageMask);

        // Kasih Damage
        foreach (Collider2D enemy in HitEnemies)
        {
           var player = enemy.GetComponent<PlayerHealth>();
           player.TakeDamage(AttackDamage);

        }
    }

    public static void AttackUp(){
        AttackDamage += 2;
    }

    public void Reset(){
        AttackDamage = 4;
    }

    private void Running ()
    {
        animator.SetFloat ("Speed", Mathf.Abs(speed));
    }

    public void Stop ()
    {
         animator.SetFloat ("Speed", 0.0f);
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.DrawWireSphere (transform.position, LineOfsite);
        Gizmos.DrawWireSphere (AttackPoint.position, AttackRange);
    }

}
