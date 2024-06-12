using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private SpriteRenderer arrow;
    private Collider2D player = null;
    private void Start()
    {
        arrow = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision;
            arrow.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        arrow.enabled = false;
        player = null;
    }
    private void Update()
    {
        if (player != null) 
        {
            if (Input.GetButtonDown("Fire2"))
            {
               
                player.gameObject.transform.position = transform.position;
               
            }
            
        }
    }
   
}
