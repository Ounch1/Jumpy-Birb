using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

/// <summary>
/// Controls the player inputs
/// </summary>
/// 
public class PlayerController : MonoBehaviour
{ 
    //[SerializeField] private AudioClip audioClip; // Example
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        //SoundManager.Instance.PlaySound(audioClip); // Example
    }

    /// <summary>
    /// Called once per frame. Check for the Space key press to call for the Jump method in playermovment.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            pm.Jump();
        }
    }
}
