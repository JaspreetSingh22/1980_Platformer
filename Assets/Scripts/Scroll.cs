using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Tooltip("How much points you get for collecting this collectable")]
    public int ScrollValue;
    
    /// <summary>
    /// This function will be called when the gameobject attached is part
    /// of a collection and one or both of the colliders are labeled 'triger'
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameStateManager.Instance.ChangeScrolls(ScrollValue);
            
            Destroy(this.gameObject);
        }
    }
}
