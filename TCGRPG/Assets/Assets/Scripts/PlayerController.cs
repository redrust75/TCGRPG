using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

	Animator anim;

	Vector3 movement;

    public Text timeText;
    
	public float speed;
	private Rigidbody rb;
    private int count;
    private float timeLeft;

	Vector3 forward, right;

    void Start(){
		anim = GetComponent <Animator> ();
		rb = GetComponent<Rigidbody> ();
		SetText ();
        timeLeft = 30.0f;
        

    }
	void FixedUpdate()
	{

		Move (0, 0);

		float x = Input.GetAxisRaw ("Horizontal");
		float z = Input.GetAxisRaw ("Vertical");
		Vector3 movement = new Vector3(x, 0.0f, z);
		// Move the player around the scene.
		Move (x, z);

		if(movement != Vector3.zero) 
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f); 

		Animating(z, x);

		timeText.text = timeLeft.ToString("F0");
		SetText ();



	}

	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		rb.MovePosition (transform.position + movement);
	}
    
    
    void SetText(){
        //count = GameObject.FindGameObjectsWithTag("Target").Length;

        timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 30.0f;
        
    }

	void Animating (float z, float x)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
		bool walking = (z != 0f) || ( x != 0f);
		 
            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", walking);
        }

	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.CompareTag("Wall"))  // or if(gameObject.CompareTag("YourWallTag"))
		{
			rb.velocity = Vector3.zero;
		}

	}
}//end playerController



/*
void FixedUpdate()
{

	Move (0, 0);

	float x = Input.GetAxisRaw ("Horizontal");
	float z = Input.GetAxisRaw ("Vertical");
	Vector3 movement = new Vector3(x, 0.0f, z);
	// Move the player around the scene.
	Move (x, z);

	if(movement != Vector3.zero) 
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f); 

	Animating(z, x);



}

void Move (float h, float v)
{
	// Set the movement vector based on the axis input.
	movement.Set (h, 0f, v);

	// Normalise the movement vector and make it proportional to the speed per second.
	movement = movement.normalized * speed * Time.deltaTime;

	// Move the player to it's current position plus the movement.
	rb.MovePosition (transform.position + movement);
}
*/