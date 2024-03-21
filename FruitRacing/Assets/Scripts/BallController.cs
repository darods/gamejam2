using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject fruit; // the prefab of the fuit selected
    public float speed = 5f; // Speed of the ball

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply force to the Rigidbody to make the ball roll
        rb.AddForce(movement * speed);
    }
}
