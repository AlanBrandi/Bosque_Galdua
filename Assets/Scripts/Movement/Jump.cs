using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{
	Animator MyAnimator;
	[Header("Jump setup")]
	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	// strength of the push
	public float jumpStrength = 10f;

	[Header("Ground setup")]
	//if the object collides with another object tagged as this, it can jump again
	public string groundTag = "Ground";
    public string groundTag1 = "Box [red]";
	public string groundTag2 = "Box [blue]";
	public string groundTag3 = "Box [green]";

	//this determines if the script has to check for when the player touches the ground to enable him to jump again
	//if not, the player can jump even while in the air
	public bool checkGround = true;

	private bool canJump = true;

    private void Start()
    {
		MyAnimator = GetComponent<Animator>();
    }

    // Read the input from the player
    void Update()
	{
		if(canJump
			&& Input.GetKeyDown(key))
		{
			// Apply an instantaneous upwards force
			rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
			canJump = !checkGround;
			MyAnimator.SetBool("IsJumping", true);
		}
	}

	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		if(checkGround
			&& collisionData.gameObject.CompareTag(groundTag))
		{
			canJump = true;
			MyAnimator.SetBool("IsJumping", false);
		}
		if (checkGround
			&& collisionData.gameObject.CompareTag(groundTag1))
		{
			canJump = true;
			MyAnimator.SetBool("IsJumping", false);
		}
		if (checkGround
			&& collisionData.gameObject.CompareTag(groundTag2))
		{
			canJump = true;
			MyAnimator.SetBool("IsJumping", false);
		}
		if (checkGround
			&& collisionData.gameObject.CompareTag(groundTag3))
		{
			canJump = true;
			MyAnimator.SetBool("IsJumping", false);
		}
	}
}