using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
   
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyKillable; 
    public float AttackRate = 2f;
    private float nextAttackTime = 0f;
    private Animator anim;




    //This is our initial start postion where our character will respawn
    private Vector3 startPostion;

    //REFF to our rigid body.
    private Rigidbody2D RB2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPostion = transform.position;

        RB2D = GetComponent<Rigidbody2D>();
        if (RB2D == null)
        {
            Debug.Log("Missing rigidbody");
        }
    }

    /// <summary>
    /// This function will handle when our player collides with a hazard
    /// </summary>
    public void OnReset()
    {
        Debug.Log("ressting player");
        //reset our player postion back ro our initial postion.
        transform.SetPositionAndRotation(startPostion, Quaternion.identity);

        //resets our velocity so that we don't get strange motion on reset
        RB2D.velocity = Vector3.zero;

    }

    public void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time >= nextAttackTime )
        {
            StartCoroutine(Attack());
            nextAttackTime = Time.time + 1f / AttackRate;
        }
      
    }
    
    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange , EnemyKillable);

        yield return new WaitForSeconds(0.3f);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HitableEnemy>().TakeDamage(40);
            Debug.Log("We Hit" + enemy.name);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    public void UpdateCheckpoint()
    {
        startPostion = transform.position;
    }
    
}


