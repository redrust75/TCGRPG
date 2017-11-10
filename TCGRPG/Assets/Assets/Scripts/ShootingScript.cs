using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

        public Rigidbody projectile;
	    public Rigidbody widePurple;
	    public Rigidbody fireBall;
	    public Rigidbody waterMine;
        public float speed;
     
        
        public void shootYellow ()
        {
            
               Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
		        
		       instantiatedProjectile.AddForce(transform.forward * speed);
            
        }

	    public void shootPurple ()
		{

			Rigidbody instantiatedPurple = Instantiate(widePurple,transform.position,transform.rotation)as Rigidbody;

			instantiatedPurple.AddForce(transform.forward * speed);

		}
		public void shootRed ()
		{

		Rigidbody instantiatedRed = Instantiate (fireBall, transform.position, fireBall.transform.rotation)as Rigidbody;

			instantiatedRed.AddForce(transform.forward * speed);

		}
		public void shootBlue ()
		{

			Rigidbody instantiatedBlue = Instantiate(waterMine,transform.position,transform.rotation)as Rigidbody;

			//instantiatedBlue.AddForce(transform.forward * speed);

		}
    }//end script
