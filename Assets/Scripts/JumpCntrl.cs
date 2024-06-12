using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCntrl : MonoBehaviour
{
    [Tooltip("Amount of force added to the player when they jump")]
    public float JumpForce = 25f;

    [Tooltip("From the centre of the character, we will check to see if we're hitting the ground")]
    public float GroundCheckDistance = -0.7f;

    private bool jump = false;    //a flag for when the player is jumping
    private bool grounded = false; //a flag if we are on the ground
  
   private Animator anim;
    Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();//looks at the components attached
        //to our game object, and IF we do have an animator, assign it
        // to our 'anim' reference
     
        if (anim == null)
        {
            Debug.LogError("You are missing an Animator on this Object!!!!");
        }
        RB = GetComponent<Rigidbody2D>();

        if (RB == null)
        {
            Debug.LogError("You're missing a Rigid Body 2D on this Object!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if we are on the ground
        grounded = Physics2D.Linecast(transform.position, transform.position + Vector3.up * GroundCheckDistance, 1 << LayerMask.NameToLayer("Ground"));


        if (grounded)
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.up * GroundCheckDistance, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.up * GroundCheckDistance, Color.red);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            grounded = false;
        }

        anim.SetBool("IsGrounded", grounded);

        if (grounded)
        {
            RB.velocity = Vector3.zero;
           
        }

    }
    private void FixedUpdate()
    {
        //Check our Jump flag
        if (jump)
        {
           
            //Add vertical force to move the player up!
            RB.AddForce(new Vector2(0f, JumpForce));

            //only add force for one frame, then toggle the flag off!
            jump = false;


        }
    }
}
