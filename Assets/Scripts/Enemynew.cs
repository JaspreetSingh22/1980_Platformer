using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemynew : MonoBehaviour
{
    [Tooltip("speed of our enemy")]
    public float Speed = 2f;
    public bool FacingRight = true;
    public float GroundCheckDistance = -0.65f;
     
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool leftGround = Physics2D.Linecast(transform.position + Vector3.left * 0.5f,
            transform.position + Vector3.left * 0.5f + Vector3.up * GroundCheckDistance,
            1 << LayerMask.NameToLayer("Ground"));

       bool rightGround = Physics2D.Linecast(transform.position + Vector3.right * 0.5f,
            transform.position + Vector3.right * 0.5f + Vector3.up * GroundCheckDistance,
            1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(transform.position + Vector3.left * 0.5f,
            transform.position + Vector3.left * 0.5f + Vector3.up * GroundCheckDistance, Color.green);
        Debug.DrawLine(transform.position + Vector3.right * 0.5f,
            transform.position + Vector3.right * 0.5f + Vector3.up * GroundCheckDistance, Color.green);


        if (!leftGround && !rightGround)
        {
            //in the air
        }
        else if (!rightGround)
        {
            FacingRight = false;
            Flip();
        }
        else if (!leftGround)
        {
            FacingRight = true;
            Flip();
        }
        if(FacingRight)
        {
            transform.Translate(Vector3.right*Speed*Time.deltaTime);
            
        }
        else
        {
            transform.Translate(Vector3.left*Speed*Time.deltaTime);
            
        }
        
    }
    private void Flip()
    {

        //facingRight = !facingRight;

        //Getting the current scale transform
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;   //flip our scale to the negative value
        transform.localScale = currentScale; //reset our scale back to the current scale

    }


}
