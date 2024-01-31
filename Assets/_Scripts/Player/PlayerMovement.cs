using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    float impulseForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        Vector2 impulse = new Vector3(0f, impulseForce);
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }
}
