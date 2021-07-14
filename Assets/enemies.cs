using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDame(int dame) {

        animator.SetTrigger("take_hit");

        currentHealth -= dame;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("enemy die...!");

        animator.SetBool("isDeath", true);

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }
}
