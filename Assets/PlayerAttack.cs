using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int attackDame_1 = 20;
    public int attackDame_2 = 40;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Attack2();
        }
    }

    void Attack() {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<enemies>().TakeDame(attackDame_1);
        }
    }

    void Attack2()
    {
        animator.SetTrigger("attack2");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemies>().TakeDame(attackDame_2);
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}