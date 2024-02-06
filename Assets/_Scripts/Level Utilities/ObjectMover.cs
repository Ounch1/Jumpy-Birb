using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Moves the object in the specified direction with the given speed.
    /// </summary>
    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
