using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private RigidBody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = getComponent<RigidBody>();
    }

    public void Jump()
    {
        Vector3 impile = new Vector3(impulseForce, of, of);
        object value = rb.AddForce(impulse, ForceMode, Impulse);
    }
}
