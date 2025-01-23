using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestPlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
    
	private Rigidbody rb;
	private Vector3 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Get input axes
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
        
		// Create movement vector and normalize to prevent diagonal speed boost
		movement = new Vector3(horizontal, 0f, vertical).normalized;
	}

	void FixedUpdate()
	{
		// Apply movement
		MoveCharacter(movement);
	}

	void MoveCharacter(Vector3 direction)
	{
		// Calculate velocity while preserving vertical velocity (for gravity/jumping)
		Vector3 targetVelocity = direction * moveSpeed;
		targetVelocity.y = rb.velocity.y;
        
		// Apply velocity
		rb.velocity = targetVelocity;
	}
}
