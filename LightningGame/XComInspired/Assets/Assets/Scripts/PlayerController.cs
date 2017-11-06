using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

	Animator anim;
    public Text timeText;
    public Text winText;

    private int count;
    private float timeLeft;
	
    void Start(){
		anim = GetComponent <Animator> ();
        count = 5;
        SetWinText();
        winText.text = "";
        timeLeft = 30.0f;
    }
    
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        Animating(z);

        timeText.text = "Time Remaining: " + timeLeft.ToString() + " seconds";
        SetWinText();
        
    }

    void SetWinText(){
        count = GameObject.FindGameObjectsWithTag("Target").Length;
        timeLeft -= Time.deltaTime;
        if(count == 0 && timeLeft > 0){
            timeText.text = "Course Completed";
            winText.text = "Course Completed";
            timeLeft = 10000000;
        }
        else if(timeLeft <= 0){
            timeLeft = 0;
            winText.text = "Course Failed";
            timeText.text = "Course Failed";
        }
    }

    void Animating (float z)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = z != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", walking);
        }


}
