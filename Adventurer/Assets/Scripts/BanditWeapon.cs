using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditWeapon : MonoBehaviour
{
	public Animator animator;
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	Transform Player;
	Rigidbody2D rb;

	public void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
	}

	public void Update ()
	{
		if (Vector2.Distance(Player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}

	}

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
			
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
