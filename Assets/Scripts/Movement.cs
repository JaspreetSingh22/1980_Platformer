using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Tooltip("Maximum speed in Unity Units per second")]
    public float Speed = 5f;

    private Animator anim;
   //reference to the player's Animation controller

    private bool facingRight = true;

    Rigidbody2D RB;                 //Reference to our physics controller

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //looks at the components attached
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
        //Gets the input value from the Horizontal Axis, raw means no interpolation
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * h * Speed * Time.deltaTime);


        //set our animation controller based off of our input
        anim.SetFloat("Speed", Mathf.Abs(h));


        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

    }

    /// <summary>
    /// This function flips our sprite!
    /// </summary>
    private void Flip()
    {

        facingRight = !facingRight;

        //Getting the current scale transform
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;   //flip our scale to the negative value
        transform.localScale = currentScale; //reset our scale back to the current scale

    }
}
