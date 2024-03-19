using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float destroyPositionX;

    private void Update()
    {
        Move();
        DestroyObject();
    }

    /// <summary>
    /// Moves the object in the specified direction with the given speed.
    /// </summary>
    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    /// <summary>
    /// Destroy the object when it moves off the scene.
    /// </summary>
    private void DestroyObject()
    {
            if(transform.position.x < destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}
