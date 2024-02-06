using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the player character.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulseForce;

    /// <summary>
    /// Called before the first frame update. Initializes the Rigidbody2D component.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handles character jumping by applying an upward force, the impulseforce is set in unity editor.
    /// </summary>
    public void Jump()
    {
        rb.velocity = Vector2.up * impulseForce; 
    }
}
