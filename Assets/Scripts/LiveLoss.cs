using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveLoss : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        StartCoroutine(Drop());
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale = 1;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
    
}
