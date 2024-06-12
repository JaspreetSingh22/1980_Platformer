using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableEnemy : MonoBehaviour
{ 
    
    public int MaxHealth = 100;
    int currentHealth;
    private Animator anim;
    public GameObject Scroll;

    public HealthbarEnemy healthbar;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("EnemyHurt");
        currentHealth -= damage;
        healthbar.UpdateHealthBar(currentHealth, MaxHealth);
        //hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(Scroll,transform.position, Quaternion.identity);
        Destroy(this.transform.parent.gameObject);
        
    }
}
